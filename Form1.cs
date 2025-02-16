using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Accès_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDirectories();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDirectories();
        }

        private void LoadDirectories()
        {
            string directoryPath = @"C:\Application\Clients\";
            if (Directory.Exists(directoryPath))
            {
                var directories = Directory.GetDirectories(directoryPath);
                flowLayoutPanelClients.Controls.Clear();

                foreach (var dir in directories)
                {
                    string dirName = Path.GetFileName(dir);

                    Button button = new Button
                    {
                        Text = dirName,
                        Tag = dir,
                        AutoSize = true
                    };

                    button.Click += DirectoryButton_Click;
                    flowLayoutPanelClients.Controls.Add(button);
                }
            }
            else
            {
                MessageBox.Show("Le répertoire spécifié n'existe pas.");
            }
        }

        private void DirectoryButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string directoryPath = button.Tag as string;
                if (directoryPath != null)
                {
                    LoadFiles(directoryPath);
                }
            }
        }

        private void LoadFiles(string directoryPath)
        {
            flowLayoutPanelAny.Controls.Clear();
            flowLayoutPanelRDS.Controls.Clear();
            flowLayoutPanelVPN.Controls.Clear();

            var files = Directory.GetFiles(directoryPath);

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);  // Récupère le nom du fichier complet (avec extension)
                string originalFileName = fileName; // Conserver le nom original pour le texte du bouton

                // Retirer l'extension du fichier
                fileName = Path.GetFileNameWithoutExtension(fileName);  // Supprime l'extension

                // Vérification du préfixe et suppression des 4 premiers caractères si nécessaire
                if (fileName.StartsWith("Any-"))
                {
                    fileName = fileName.Substring(4); // Retirer "Any-"
                }
                else if (fileName.StartsWith("RDS-"))
                {
                    fileName = fileName.Substring(4); // Retirer "RDS-"
                }
                else if (fileName.StartsWith("VPN-"))
                {
                    fileName = fileName.Substring(4); // Retirer "VPN-"
                }

                // Créer le bouton avec le nom modifié (sans extension ni préfixe)
                Button button = new Button
                {
                    Text = fileName,  // Afficher le nom modifié (sans l'extension et préfixe)
                    Tag = file,  // Le chemin complet du fichier
                    AutoSize = true
                };

                button.Click += FileButton_Click;

                // Catégoriser le fichier en fonction du préfixe d'origine
                if (originalFileName.StartsWith("Any-"))
                {
                    flowLayoutPanelAny.Controls.Add(button);
                }
                else if (originalFileName.StartsWith("RDS-"))
                {
                    flowLayoutPanelRDS.Controls.Add(button);
                }
                else if (originalFileName.StartsWith("VPN-"))
                {
                    flowLayoutPanelVPN.Controls.Add(button);
                }
                else
                {
                    // Si le fichier ne commence pas par "Any-", "RDS-" ou "VPN-", on ne l'ajoute à aucun panneau
                    // ou on peut décider de l'ajouter à un panneau par défaut.
                }
            }
        }



        private void FileButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string filePath = button.Tag as string;
                if (filePath != null)
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
            }
        }
    }
}
