using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int x=0;
            int y = 0;
            byte[] b;
            String gs="";
            button1.Text= "loading wait...";
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            pictureBox1.Load();
            Bitmap image1 = new Bitmap(openFileDialog1.FileName, true);
            byte[] i=new byte[1];
            i[0]= 0;
            FileStream file;
            this.Text = System.IO.Directory.GetCurrentDirectory();
            file = new FileStream("out.array",
                                  FileMode.Create,
                                  FileAccess.Write);





            i[0] = 24;
            file.Write(i, 0, 1);
            i[0] = 0;
            file.Write(i, 0, 1);
            file.Write(i, 0, 1);
            file.Write(i, 0, 1);
            int ii = 0;
            ii = 0xff & pictureBox1.Image.Width;
            i[0] = (byte)ii;
            file.Write(i, 0, 1);
            i[0] = 0;
            file.Write(i, 0, 1);
            file.Write(i, 0, 1);
            file.Write(i, 0, 1);
            ii = 0xff & pictureBox1.Image.Height;
            i[0] = (byte)ii;
            file.Write(i, 0, 1);
            i[0] = 0;
            file.Write(i, 0, 1);
            file.Write(i, 0, 1);
            file.Write(i, 0, 1);

            Application.DoEvents();
         for (y=0; y < pictureBox1.Image.Height; y++)
            {
                for (x = 0; x < pictureBox1.Image.Width; x++)
                {
                    Color pixelColor = image1.GetPixel(x, y);

                    i[0] = (byte)pixelColor.B;
                    file.Write(i, 0, 1);
                    i[0] = (byte)pixelColor.G;
                    file.Write(i, 0, 1);
                    i[0] = (byte)pixelColor.R;
                    file.Write(i, 0, 1);

                }

           }
            gs = gs + "0};";
            file.Close();
            button1.Text = "open bitmap";
        }
    }
}