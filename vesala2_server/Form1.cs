
namespace vesala2_server
{
    public partial class Form1 : Form
    {
        public string recZaPogadjanje;
        public int prviKorBrPok = 0;
        public int drugiKorBrPok = 0;
        public int prviKorBrPokUsp = 0;
        public int drugiKorBrPokUsp = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void SetRecZaPogadjanje(string v)
        {
            recZaPogadjanje = v;
            label1.Text = recZaPogadjanje;
        }

        public void SetPrviKorisnik(string v)
        {
            label2.Invoke(new Action(() => { 
                label2.Text = v;
            }));
        }

        public void SetDrugiKorisnik(string v)
        {
            label3.Invoke(new Action(() => {
                label3.Text = v;
            }));
        }
    }
}
