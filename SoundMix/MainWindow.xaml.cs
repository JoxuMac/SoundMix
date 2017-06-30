using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace SoundMix
{
    public partial class MainWindow : Window
    {
        /*************
         * VARIABLES *
         *************/
        MediaPlayer playerPuerta = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerZombies = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerAvalancha = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerOrcos = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerLobos = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerCadenas = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerRisa1 = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerRisa2 = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerFuego = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerViento = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerAgua = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerCanones = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerCuerno = new System.Windows.Media.MediaPlayer();
        MediaPlayer playerTormenta = new System.Windows.Media.MediaPlayer();
        MediaPlayer MusicPlayer = new System.Windows.Media.MediaPlayer();

        bool loopZombies = false;
        bool loopOrcos = false;
        bool loopPuerta = false;
        bool loopAvalancha = false;
        bool loopLobos = false;
        bool loopCadenas = false;
        bool loopRisa1 = false;
        bool loopRisa2 = false;
        bool loopFuego = false;
        bool loopViento = false;
        bool loopAgua = false;
        bool loopCanones = false;
        bool loopCuerno = false;
        bool loopTormenta = false;
        bool loopPlayer = false;
        bool reproduciendo = false;

        /**************
         * INICIACION *
         **************/
        public MainWindow()
        {
            InitializeComponent();
            loadMusic();
        }

        /***********************
         * CARGAR MUSICA FONDO *
         ***********************/
        private void loadMusic()
        {
            int type = -1; // 0 Enemigos, 1 Combate, 2 Lugares

            XmlTextReader myXMLreader = new XmlTextReader(@"" + System.IO.Directory.GetCurrentDirectory() + "/music/music.xml");
            
            while (myXMLreader.Read())
            {
                myXMLreader.MoveToContent();
                if (myXMLreader.NodeType == System.Xml.XmlNodeType.Element)
                    if (myXMLreader.Name == "Enemigos")
                        type = 0;
                    else if (myXMLreader.Name == "Combate")
                        type = 1;
                    else if (myXMLreader.Name == "Lugares")
                        type = 2;

                if (myXMLreader.NodeType == System.Xml.XmlNodeType.Text)
                    if (type == 0)
                        lbxEnemigos.Items.Add(myXMLreader.Value);
                    else if (type == 1)
                        lbxCombate.Items.Add(myXMLreader.Value);
                    else if (type == 2)
                        lbxLugares.Items.Add(myXMLreader.Value);
            }
        }

        /*********************
         * REPRODUCIR SONIDO *
         *********************/
        private void reproducirSonido(String sonido)
        {
            switch (sonido)
            {
                case "Puerta":
                    playerPuerta.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/puerta.wav"));
                    playerPuerta.MediaEnded += playerPuerta_MediaEnded;
                    playerPuerta.Play();

                    lblSoundPuerta.Visibility = System.Windows.Visibility.Visible;
                    btnStopPuerta.IsEnabled = true;
                    break;

                case "Zombies":
                    playerZombies.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/zombie.wav"));
                    playerZombies.MediaEnded += playerZombies_MediaEnded;
                    playerZombies.Play();

                    lblSoundZombies.Visibility = System.Windows.Visibility.Visible;
                    btnStopZombies.IsEnabled = true;
                    break;

                case "Avalancha":
                    playerAvalancha.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/avalancha.wav"));
                    playerAvalancha.MediaEnded += playerAvalancha_MediaEnded;
                    playerAvalancha.Play();

                    lblSoundAvalancha.Visibility = System.Windows.Visibility.Visible;
                    btnStopAvalancha.IsEnabled = true;
                    break;

                case "Orcos":
                    playerOrcos.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/orcos.wav"));
                    playerOrcos.MediaEnded += playerOrcos_MediaEnded;
                    playerOrcos.Play();

                    lblSoundOrcos.Visibility = System.Windows.Visibility.Visible;
                    btnStopOrcos.IsEnabled = true;
                    break;

                case "Lobos":
                    playerLobos.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/lobos.wav"));
                    playerLobos.MediaEnded += playerLobos_MediaEnded;
                    playerLobos.Play();

                    lblSoundLobos.Visibility = System.Windows.Visibility.Visible;
                    btnStopLobos.IsEnabled = true;
                    break;

                case "Cadenas":
                    playerCadenas.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/cadenas.wav"));
                    playerCadenas.MediaEnded += playerCadenas_MediaEnded;
                    playerCadenas.Play();

                    lblSoundCadenas.Visibility = System.Windows.Visibility.Visible;
                    btnStopCadenas.IsEnabled = true;
                    break;

                case "Risa 1":
                    playerRisa1.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/risa1.wav"));
                    playerRisa1.MediaEnded += playerRisa1_MediaEnded;
                    playerRisa1.Play();

                    lblSoundRisa1.Visibility = System.Windows.Visibility.Visible;
                    btnStopRisa1.IsEnabled = true;
                    break;

                case "Risa 2":
                    playerRisa2.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/risa2.wav"));
                    playerRisa2.MediaEnded += playerRisa2_MediaEnded;
                    playerRisa2.Play();

                    lblSoundRisa2.Visibility = System.Windows.Visibility.Visible;
                    btnStopRisa2.IsEnabled = true;
                    break;

                case "Fuego":
                    playerFuego.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/fuego.wav"));
                    playerFuego.MediaEnded += playerFuego_MediaEnded;
                    playerFuego.Play();

                    lblSoundFuego.Visibility = System.Windows.Visibility.Visible;
                    btnStopFuego.IsEnabled = true;
                    break;

                case "Viento":
                    playerViento.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/viento.wav"));
                    playerViento.MediaEnded += playerViento_MediaEnded;
                    playerViento.Play();

                    lblSoundViento.Visibility = System.Windows.Visibility.Visible;
                    btnStopViento.IsEnabled = true;
                    break;

                case "Agua":
                    playerAgua.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/agua.wav"));
                    playerAgua.MediaEnded += playerAgua_MediaEnded;
                    playerAgua.Play();

                    lblSoundAgua.Visibility = System.Windows.Visibility.Visible;
                    btnStopAgua.IsEnabled = true;
                    break;

                case "Cañones":
                    playerCanones.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/canones.wav"));
                    playerCanones.MediaEnded += playerCanones_MediaEnded;
                    playerCanones.Play();

                    lblSoundCanones.Visibility = System.Windows.Visibility.Visible;
                    btnStopCanones.IsEnabled = true;
                    break;

                case "Cuerno":
                    playerCuerno.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/cuerno.wav"));
                    playerCuerno.MediaEnded += playerCuerno_MediaEnded;
                    playerCuerno.Play();

                    lblSoundCuerno.Visibility = System.Windows.Visibility.Visible;
                    btnStopCuerno.IsEnabled = true;
                    break;

                case "Tormenta":
                    playerTormenta.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/sounds/tormenta.wav"));
                    playerTormenta.MediaEnded += playerTormenta_MediaEnded;
                    playerTormenta.Play();

                    lblSoundTormenta.Visibility = System.Windows.Visibility.Visible;
                    btnStopTormenta.IsEnabled = true;
                    break;
            }
        }

        /*************************
         * OYENTE BOTONES SONIDO *
         *************************/
        private void btnSonido(object sender, RoutedEventArgs e)
        {
            reproducirSonido((String)(sender as Button).Content);
        }

        /********************
         * FINALIZAR SONIDO *
         ********************/
        void playerOrcos_MediaEnded(object sender, EventArgs e)
        {
            if (loopOrcos)
                reproducirSonido("Orcos");
            else
            {
                btnStopOrcos.IsEnabled = false;
                lblSoundOrcos.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerZombies_MediaEnded(object sender, EventArgs e)
        {
            if (loopZombies)
                reproducirSonido("Zombies");
            else
            {
                btnStopZombies.IsEnabled = false;
                lblSoundZombies.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerLobos_MediaEnded(object sender, EventArgs e)
        {
            if (loopLobos)
                reproducirSonido("Lobos");
            else
            {
                btnStopLobos.IsEnabled = false;
                lblSoundLobos.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerRisa1_MediaEnded(object sender, EventArgs e)
        {
            if (loopRisa1)
                reproducirSonido("Risa 1");
            else
            {
                btnStopRisa1.IsEnabled = false;
                lblSoundRisa1.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerRisa2_MediaEnded(object sender, EventArgs e)
        {
            if (loopRisa2)
                reproducirSonido("Risa 2");
            else
            {
                btnStopRisa2.IsEnabled = false;
                lblSoundRisa2.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerCadenas_MediaEnded(object sender, EventArgs e)
        {
            if (loopCadenas)
                reproducirSonido("Cadenas");
            else
            {
                btnStopCadenas.IsEnabled = false;
                lblSoundCadenas.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerAvalancha_MediaEnded(object sender, EventArgs e)
        {
            if (loopAvalancha)
                reproducirSonido("Avalancha");
            else
            {
                btnStopAvalancha.IsEnabled = false;
                lblSoundAvalancha.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerPuerta_MediaEnded(object sender, EventArgs e)
        {
            if (loopPuerta)
                reproducirSonido("Puerta");
            else
            {
                btnStopPuerta.IsEnabled = false;
                lblSoundPuerta.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerFuego_MediaEnded(object sender, EventArgs e)
        {
            if (loopFuego)
                reproducirSonido("Fuego");
            else
            {
                btnStopFuego.IsEnabled = false;
                lblSoundFuego.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerAgua_MediaEnded(object sender, EventArgs e)
        {
            if (loopAgua)
                reproducirSonido("Agua");
            else
            {
                btnStopAgua.IsEnabled = false;
                lblSoundAgua.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerViento_MediaEnded(object sender, EventArgs e)
        {
            if (loopViento)
                reproducirSonido("Viento");
            else
            {
                btnStopViento.IsEnabled = false;
                lblSoundViento.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerCanones_MediaEnded(object sender, EventArgs e)
        {
            if (loopCanones)
                reproducirSonido("Cañones");
            else
            {
                btnStopCanones.IsEnabled = false;
                lblSoundCanones.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerCuerno_MediaEnded(object sender, EventArgs e)
        {
            if (loopCuerno)
                reproducirSonido("Cuerno");
            else
            {
                btnStopCuerno.IsEnabled = false;
                lblSoundCuerno.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerTormenta_MediaEnded(object sender, EventArgs e)
        {
            if (loopTormenta)
                reproducirSonido("Tormenta");
            else
            {
                btnStopTormenta.IsEnabled = false;
                lblSoundTormenta.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void playerMusic_MediaEnded(object sender, EventArgs e)
        {
            if (loopPlayer)
                reproducirMusica(lblSonando.Content.ToString());
            else
            {
                btnStop.IsEnabled = false;
                reproduciendo = false;
            }
        }

        /***********************
         * OYENTE BOTONES LOOP *
         ***********************/
        private void btnLoopOrcos_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopOrcos)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopOrcos = !loopOrcos;
            btnLoopOrcos.Background = brush;
        }

        private void btnLoopZombies_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopZombies)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopZombies = !loopZombies;
            btnLoopZombies.Background = brush;
        }

        private void btnLoopLobos_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopLobos)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopLobos = !loopLobos;
            btnLoopLobos.Background = brush;
        }

        private void btnLoopRisa1_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopRisa1)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopRisa1 = !loopRisa1;
            btnLoopRisa1.Background = brush;
        }

        private void btnLoopRisa2_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopRisa2)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopRisa2 = !loopRisa2;
            btnLoopRisa2.Background = brush;
        }

        private void btnLoopCadenas_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopCadenas)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopCadenas = !loopCadenas;
            btnLoopCadenas.Background = brush;
        }

        private void btnLoopAvalancha_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopAvalancha)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopAvalancha = !loopAvalancha;
            btnLoopAvalancha.Background = brush;
        }

        private void btnLoopPuerta_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopPuerta)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopPuerta = !loopPuerta;
            btnLoopPuerta.Background = brush;
        }

        private void btnLoopFuego_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopFuego)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopFuego = !loopFuego;
            btnLoopFuego.Background = brush;
        }

        private void btnLoopAgua_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopAgua)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopAgua = !loopAgua;
            btnLoopAgua.Background = brush;
        }

        private void btnLoopViento_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopViento)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopViento = !loopViento;
            btnLoopViento.Background = brush;
        }

        private void btnLoopCanones_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopCanones)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopCanones = !loopCanones;
            btnLoopCanones.Background = brush;
        }

        private void btnLoopCuerno_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopCuerno)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopCuerno = !loopCuerno;
            btnLoopCuerno.Background = brush;
        }

        private void btnLoopTormenta_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopTormenta)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopTormenta = !loopTormenta;
            btnLoopTormenta.Background = brush;
        }
        
        /***********************
         * OYENTE BOTONES STOP *
         ***********************/
        private void btnStopZombies_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopZombies.IsEnabled)
            {
                playerZombies.Stop();
                btnStopZombies.IsEnabled = false;
                lblSoundZombies.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopOrcos_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopOrcos.IsEnabled)
            {
                playerOrcos.Stop();
                btnStopOrcos.IsEnabled = false;
                lblSoundOrcos.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopLobos_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopLobos.IsEnabled)
            {
                playerLobos.Stop();
                btnStopLobos.IsEnabled = false;
                lblSoundLobos.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopRisa1_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopRisa1.IsEnabled)
            {
                playerRisa1.Stop();
                btnStopRisa1.IsEnabled = false;
                lblSoundRisa1.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopRisa2_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopRisa2.IsEnabled)
            {
                playerRisa2.Stop();
                btnStopRisa2.IsEnabled = false;
                lblSoundRisa2.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopCadenas_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopCadenas.IsEnabled)
            {
                playerCadenas.Stop();
                btnStopCadenas.IsEnabled = false;
                lblSoundCadenas.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopAvalancha_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopAvalancha.IsEnabled)
            {
                playerAvalancha.Stop();
                btnStopAvalancha.IsEnabled = false;
                lblSoundAvalancha.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopPuerta_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopPuerta.IsEnabled)
            {
                playerPuerta.Stop();
                btnStopPuerta.IsEnabled = false;
                lblSoundPuerta.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopFuego_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopFuego.IsEnabled)
            {
                playerFuego.Stop();
                btnStopFuego.IsEnabled = false;
                lblSoundFuego.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopAgua_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopAgua.IsEnabled)
            {
                playerAgua.Stop();
                btnStopAgua.IsEnabled = false;
                lblSoundAgua.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopViento_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopViento.IsEnabled)
            {
                playerViento.Stop();
                btnStopViento.IsEnabled = false;
                lblSoundViento.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopCanones_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopCanones.IsEnabled)
            {
                playerCanones.Stop();
                btnStopCanones.IsEnabled = false;
                lblSoundCanones.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopCuerno_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopCuerno.IsEnabled)
            {
                playerCuerno.Stop();
                btnStopCuerno.IsEnabled = false;
                lblSoundCuerno.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnStopTormenta_Click(object sender, RoutedEventArgs e)
        {
            if (btnStopTormenta.IsEnabled)
            {
                playerTormenta.Stop();
                btnStopTormenta.IsEnabled = false;
                lblSoundTormenta.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        /******************************
         * OYENTE BOTONES REPRODUCTOR *
         ******************************/
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if(!lblSonando.Content.ToString().Equals(""))
            { 
                if (reproduciendo)
                {
                    ImageBrush brush = new ImageBrush();
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/play.png");
                    bi.EndInit();
                    brush.ImageSource = bi;
                    btnPlay.Background = brush;
                    MusicPlayer.Pause();
                    reproduciendo = false;
                }
                else
                {
                    ImageBrush brush = new ImageBrush();
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/pausa.png");
                    bi.EndInit();
                    brush.ImageSource = bi;
                    btnPlay.Background = brush;
                    MusicPlayer.Play();
                    reproduciendo = true;
                }
                btnStop.IsEnabled = true;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (btnStop.IsEnabled)
            {
                MusicPlayer.Stop();
                btnStop.IsEnabled = false;
                reproduciendo = false;

                ImageBrush brush = new ImageBrush();
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/play.png");
                bi.EndInit();
                brush.ImageSource = bi;
                btnPlay.Background = brush;
            }
        }

        private void btnLoop_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            if (loopPlayer)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/noloop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/loop.png");
                bi.EndInit();
                brush.ImageSource = bi;
            }
            loopPlayer = !loopPlayer;
            btnLoop.Background = brush;
        }

        private void reproducirMusica(String musica)
        {
            MusicPlayer.Open(new System.Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/music/"+musica));
            MusicPlayer.MediaEnded += playerMusic_MediaEnded;
            MusicPlayer.Play();

            ImageBrush brush = new ImageBrush();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(@"" + System.IO.Directory.GetCurrentDirectory() + "/src/pausa.png");
            bi.EndInit();
            brush.ImageSource = bi;
            btnPlay.Background = brush;

            btnStop.IsEnabled = true;
            reproduciendo = true;
        }

        private void lbxCombate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbxCombate.SelectedItem != null)
            {
                lblSonando.Content = lbxCombate.SelectedItem.ToString();
                reproducirMusica(lblSonando.Content.ToString());
            }
        }

        private void lbxEnemigos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbxEnemigos.SelectedItem != null)
            {
                lblSonando.Content = lbxEnemigos.SelectedItem.ToString();
                reproducirMusica(lblSonando.Content.ToString());
            }
        }

        private void lbxLugares_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbxLugares.SelectedItem != null)
            {
                lblSonando.Content = lbxLugares.SelectedItem.ToString();
                reproducirMusica(lblSonando.Content.ToString());
            }
        }
    }
}