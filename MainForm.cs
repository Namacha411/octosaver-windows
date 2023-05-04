namespace octosaver_windows;

public partial class MainForm : Form
{
    private Point _mouseLocation;
    private readonly System.Windows.Forms.Timer _timer = new();
    private ParseRSS _view = new();

    const int intervalTime = 5 * 1000; // ms

    public MainForm()
    {
        Initialize();
    }

    public MainForm(Rectangle bounds)
    {
        Initialize();
        Bounds = bounds;
        title.Location = new Point(bounds.Width / 2, bounds.Height * 3 / 4);
    }

    private async void Initialize()
    {
        InitializeComponent();
        InitTimer();
        _view = await ParseRSS.SetOctocatInfos();
        BackgroundImageLayout = ImageLayout.Zoom;
        Cursor.Hide();
    }

    public async void SetRandomImage()
    {
        var info = await ParseRSS.GetRandomOctocatInfoAsync();
        var webClient = new HttpClient();
        var bytesImage = await webClient.GetByteArrayAsync(info.ImageUrl);
        BackgroundImage = Image.FromStream(new MemoryStream(bytesImage));
        title.Text = info.Name;
    }

    public async void SetRandomImage(object? sender, EventArgs e)
    {
        var info = _view.GetRandomOctocatInfo();
        var webClient = new HttpClient();
        var bytesImage = await webClient.GetByteArrayAsync(info.ImageUrl);
        BackgroundImage = Image.FromStream(new MemoryStream(bytesImage));
        title.Text = info.Name;
    }

    private void InitTimer()
    {
        SetRandomImage();
        _timer.Tick += SetRandomImage;
        _timer.Interval = intervalTime;
        _timer.Start();
    }

    private bool IsMouseMoved(object sender, MouseEventArgs e)
    {
        if (!_mouseLocation.IsEmpty)
        {
            if (_mouseLocation != e.Location) return true;
        }
        _mouseLocation = e.Location;
        return false;
    }

    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
        if (IsMouseMoved(sender, e))
        {
            Application.Exit();
        }
    }

    private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
    {
        Application.Exit();
    }

    private void MainForm_MouseClick(object sender, MouseEventArgs e)
    {
        Application.Exit();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }
}
