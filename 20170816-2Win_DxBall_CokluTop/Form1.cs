using System;
using System.Drawing;
using System.Windows.Forms;

namespace _20170816_2Win_DxBall_CokluTop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            RadioButton rdb = new RadioButton(); // bu yaptığımıza runtime sırasında nesne eklemek deniyor. program çalışırken nesneyi belli bir koşula göre üretme ve form üzerine çizme işlemi yapıyoruz.
            rdb.Text = null;
            rdb.Width = rdb.Height - 10; // eğer rdb yi kare olarak düşünürsek yükseklik ve genişlik birbirine eşit olacaktır. böylece yazının geleceği aralığı büyük bırakma sorunu giderilir.
            rdb.Checked = true;

            rdb.Left = e.X;
            rdb.Top = e.Y;
            rdb.Tag = new Point(2, 2);

            this.Controls.Add(rdb);
        }


        /*
         * Topların hareket ederken birbirlerine çarpma olayını ekliyoruz.
         * her noktadan aşağıdaki şekilde kontrol yapmamız gerekiyor. fazla amelelik yapmaya gerek yok. boşver :D
         * çok gerekirse uğraşırız mecburen.
         */
        bool TopXCarpti(RadioButton top)
        {
            //foreach (RadioButton _top in this.Controls)
            //{
            //    if (top!=_top && (top.Left <= _top.Right && top.Left >= _top.Left && top.Top >= _top.Top && top.Top <= _top.Bottom))
            //    {
            //        return true;
            //    }
            //}
            return false;
        }


        // Point struct olduğu için point.Y *= -1; gibi bir kullanım yapamıyoruz. Ona Ek olarak yerine top nesnesinin tag özelliğine tekrar pointi atamamız gerekir

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (RadioButton top in this.Controls)
            {
                Point point = (Point)top.Tag;
                top.Left += point.X;
                top.Top += point.Y;
                if (top.Left <= 0 || top.Right >= this.ClientSize.Width || TopXCarpti(top))
                {
                    point.X *= -1;
                }

                if (top.Top <= 0 || top.Bottom >= this.ClientSize.Height || TopXCarpti(top))
                {
                    point.Y *= -1;
                }

                top.Tag = point;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
