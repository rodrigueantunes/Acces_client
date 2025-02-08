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
            string directoryPath = @"C:\Application\Clients\"; // Remplacez par le chemin de votre répertoire
            if (Directory.Exists(directoryPath))
            {
                var directories = Directory.GetDirectories(directoryPath);
                foreach (var dir in directories)
                {
                    string dirName = Path.GetFileName(dir);
                    if (!flowLayoutPanel1.Controls.OfType<Button>().Any(b => b.Text == dirName))
                    {
                        Button button = new Button
                        {
                            Text = dirName,
                            Tag = dir,
                            AutoSize = true
                        };
                        button.Click += DirectoryButton_Click;
                        flowLayoutPanel1.Controls.Add(button);
                    }
                }
            }
            else
            {
                MessageBox.Show("Le répertoire spécifié n'existe pas.");
            }
        }

        private void DirectoryButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string? directoryPath = button.Tag as string;
                if (directoryPath != null)
                {
                    LoadFiles(directoryPath);
                }
            }
        }

        private void LoadFiles(string directoryPath)
        {
            flowLayoutPanel1.Controls.Clear(); // Clear existing buttons

            var files = Directory.GetFiles(directoryPath);
            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (!flowLayoutPanel1.Controls.OfType<Button>().Any(b => b.Text == fileName))
                {
                    Button button = new Button
                    {
                        Text = fileName,
                        Tag = file,
                        AutoSize = true
                    };
                    button.Click += FileButton_Click;
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
        }

        private void FileButton_Click(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string? filePath = button.Tag as string;
                if (filePath != null)
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
            }
        }
    }
}