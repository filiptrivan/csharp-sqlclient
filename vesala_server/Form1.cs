using System.Text.Json;
using vesala_server;

namespace vesala_client
{
    public partial class Form1 : Form
    {
        public string ClientId { get; set; } = Guid.NewGuid().ToString();

        public Form1()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pokusaj = new Pokusaj
            {
                Id = ClientId,
                ZadnjeSlovo = textBox6.Text,
            };

            Helper.Request(new Request
            {
                Data = JsonSerializer.Serialize(pokusaj),
                MethodName = "Pokusaj"
            });
        }
    }
}
