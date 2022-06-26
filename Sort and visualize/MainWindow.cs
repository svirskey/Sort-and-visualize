using System.Drawing.Imaging;


namespace Sort_and_visualize
{

    public partial class MainWindow : Form
    {
        private Graphics graphics;
        private Strct strct;

        public MainWindow()
        {
            InitializeComponent(); 
            strct = new Strct();
            strct.fill_array();
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppArgb);
            graphics = Graphics.FromImage(bitmap);

            for (int i = 0; i < strct.size; i++)
            {
                graphics.FillRectangle(Brushes.Tomato, i * pictureBox1.Width / strct.size,
                    (pictureBox1.Height - (strct.lst[i]) * pictureBox1.Height / (strct.max - strct.min)),
                    (int)(pictureBox1.Width / (strct.size * 1.1)),
                    ((strct.lst[i]) * pictureBox1.Height / (strct.max - strct.min)));
            }

            this.pictureBox1.Image = bitmap;
            timer1.Start();
        }

        private void DrawSwaps(int i, int j)
        {

            graphics.FillRectangle(Brushes.Black, i * pictureBox1.Width / strct.size,
                    (pictureBox1.Height - (strct.lst[i]) * pictureBox1.Height / (strct.max - strct.min)),
                    (int)(pictureBox1.Width / (strct.size * 1.1)),
                    ((strct.lst[i]) * pictureBox1.Height / (strct.max - strct.min)));

            graphics.FillRectangle(Brushes.Tomato, i * pictureBox1.Width / strct.size,
                    (pictureBox1.Height - (strct.lst[j]) * pictureBox1.Height / (strct.max - strct.min)),
                    (int)(pictureBox1.Width / (strct.size * 1.1)),
                    ((strct.lst[j]) * pictureBox1.Height / (strct.max - strct.min)));

            graphics.FillRectangle(Brushes.Black, j * pictureBox1.Width / strct.size,
                   (pictureBox1.Height - (strct.lst[j]) * pictureBox1.Height / (strct.max - strct.min)),
                   (int)(pictureBox1.Width / (strct.size * 1.1)),
                   ((strct.lst[j]) * pictureBox1.Height / (strct.max - strct.min)));

            graphics.FillRectangle(Brushes.Tomato, j * pictureBox1.Width / strct.size,
                    (pictureBox1.Height - (strct.lst[i]) * pictureBox1.Height / (strct.max - strct.min)),
                    (int)(pictureBox1.Width / (strct.size * 1.1)),
                    ((strct.lst[i]) * pictureBox1.Height / (strct.max - strct.min)));
            pictureBox1.Refresh();
        }

        public void BubbleSort()
        {
            this.Text = "BubbleSort";
            for (int j = 1; j < strct.size; j++)
            {
                int f = 0;
                for (int i = 0; i < strct.size - j; i++)
                {
                    if (strct.lst[i] > strct.lst[i + 1])
                    {
                        DrawSwaps(i , i + 1);
                        var tmp = strct.lst[i];
                        strct.lst[i] = strct.lst[i + 1];
                        strct.lst[i + 1] = tmp;
                        f = 1;
                    }
                    if (f == 1)
                        continue;
                }
            }
        }
        public void SelectionSort()
        {
            this.Text = "SelectionSort";
            for (int i = 0; i < strct.size - 1; ++i)
            {
                int min = i;
                for (int j = i + 1; j < strct.size; ++j)
                {
                    if (strct.lst[j] < strct.lst[min])
                    {
                        min = j;
                    }
                }
                Thread.Sleep(50);

                DrawSwaps(i, min);
                var dummy = strct.lst[i];
                strct.lst[i] = strct.lst[min];
                strct.lst[min] = dummy;
            }
        }

        public partial class Strct
        {
            public int size;
            public int min;
            public int max;

            public List<int> lst = new List<int>();

            public void fill_array(int size = 100, int min = 0, int max = 100)
            {
                this.size = size;
                this.min = min;
                this.max = max;

                var rand = new Random();
                for (int i = 0; i < size; i++)
                {
                    lst.Add(rand.Next(min, max));
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             BubbleSort();
           // SelectionSort(); // TODO new form to choose sort type
            timer1.Stop();
        }
    }
}