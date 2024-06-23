namespace CoinFlip
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            int moeda = new Random().Next(2);
            
            if (moeda == 0)
                moedaimagem.Source ="cara.jfif";
            else
                moedaimagem.Source = "coroa.jpg";



            string lado = Convert.ToString(escolha.SelectedItem);

            if(lado == "cara" && moeda == 0 || lado == "coroa" && moeda == 1)
            {
                resultado.Text = "Você venceu";
            }
            else
            {
                resultado.Text = "Você perdeu";
            }

        }
    }

}
