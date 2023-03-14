using System;
using System.Drawing;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data;
using System.IO;
using  System.Resources;

namespace ALVImageBrowser
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private ALV.ALVCS03CONTROLS.ALVImageViewer alvImageViewer1;
		private System.Windows.Forms.TreeView directoryViewer;		
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label lblPage;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private string fullPath = "D:\\Code\\PHP\\uploads";
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		
		protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY && (int)m.WParam == HOTKEY_ID)
            {
                fullPath = "D:\\Code\\PHP\\uploads";
				folderBrowserDialog1.SelectedPath = fullPath;                 
            	lblPath.Text = fullPath;
				listBox1.Items.Clear();
				PopulateTreeView();
				
            }
            else if (m.Msg == WM_KEYDOWN || m.Msg == WM_SYSKEYDOWN)
            {
                Keys key = (Keys)m.WParam.ToInt32();

                // Handle regular key press here
                if (key == Keys.Escape)
                {
                    Close();
                }
            }
        }

        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID = 1;


		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			if (!RegisterHotKey(Handle, HOTKEY_ID, 0, (uint)Keys.F5))
            {
                
            }
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			UnregisterHotKey(Handle, HOTKEY_ID);

			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblPath = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.alvImageViewer1 = new ALV.ALVCS03CONTROLS.ALVImageViewer();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.lblPage = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			
			this.directoryViewer = new System.Windows.Forms.TreeView();
			
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Open Folder";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			
			// Create a new font with the desired size
			Font currentFont = directoryViewer.Font;
			int desiredFontSize = 10;
			Font newFont = new Font(currentFont.FontFamily, desiredFontSize, currentFont.Style);
			
			//directoryViewer
			this.directoryViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.directoryViewer.Location = new System.Drawing.Point(8, 40);
			this.directoryViewer.Name = "directoryViewer";
			this.directoryViewer.Size = new System.Drawing.Size(276, 30);
			this.directoryViewer.Sorted = true;
			this.directoryViewer.TabIndex = 2;
			this.directoryViewer.Font = newFont;
			this.directoryViewer.AfterSelect += this.directoryViewer_AfterSelect;
			
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.listBox1.Location = new System.Drawing.Point(8, 507);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(276, 63);
			this.listBox1.Sorted = true;
			this.listBox1.HorizontalScrollbar = true;
			this.listBox1.TabIndex = 3;
			this.listBox1.Font = newFont;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);			
			
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(112, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(380, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Current Path : ";
			
			this.label3.Location = new System.Drawing.Point(600, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(680, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Current File Name :";
			// 
			// lblPath
			// 
			this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblPath.Location = new System.Drawing.Point(192, 16);
			this.lblPath.Name = "lblPath";
			this.lblPath.Text = fullPath;
			this.lblPath.Size = new System.Drawing.Size(592, 16);
			this.lblPath.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(16, 528);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 32);
			this.label2.TabIndex = 7;
			this.label2.Hide();
			this.label2.Text = "Image Viewer ver 1.0.0 Copyright 2023";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// alvImageViewer1
			// 
			this.alvImageViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.alvImageViewer1.AutoFitToHeight = false;
			this.alvImageViewer1.AutoFitToScreen = false;
			this.alvImageViewer1.AutoFitToWidth = false;
			this.alvImageViewer1.BackColor = System.Drawing.SystemColors.Control;
			this.alvImageViewer1.Location = new System.Drawing.Point(292, 40);
			this.alvImageViewer1.Name = "alvImageViewer1";
			this.alvImageViewer1.Size = new System.Drawing.Size(492, 520);
			this.alvImageViewer1.TabIndex = 11;
			this.alvImageViewer1.ZoomRatio = 1;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(1725, 472);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(88, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = "Rotate L";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Location = new System.Drawing.Point(1810, 472);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 24);
			this.button3.TabIndex = 5;
			this.button3.Text = "Rotate R";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button4.Location = new System.Drawing.Point(1790, 464);
			this.button4.Name = "button4";
			this.button4.Hide();
			this.button4.Size = new System.Drawing.Size(88, 24);
			this.button4.TabIndex = 11;
			this.button4.Text = "&Next >>";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button5.Location = new System.Drawing.Point(8, 464);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(88, 24);
			this.button5.TabIndex = 10;
			this.button5.Hide();
			this.button5.Text = "<< &Previous";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button6.Location = new System.Drawing.Point(1725, 496);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(88, 24);
			this.button6.TabIndex = 7;
			this.button6.Text = "Flip V";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button7.Location = new System.Drawing.Point(1810, 496);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(88, 24);
			this.button7.TabIndex = 6;
			this.button7.Text = "Flip H";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button8.Location = new System.Drawing.Point(1725, 520);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(88, 24);
			this.button8.TabIndex = 9;
			this.button8.Text = "Zoom Out(&-)";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button9.Location = new System.Drawing.Point(1810, 520);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(88, 24);
			this.button9.TabIndex = 8;
			this.button9.Text = "Zoom In(&+)";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// lblPage
			// 
			this.lblPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblPage.Location = new System.Drawing.Point(16, 496);
			this.lblPage.Name = "lblPage";
			this.lblPage.Size = new System.Drawing.Size(168, 24);
			this.lblPage.TabIndex = 12;
			// 
			// radioButton1
			// 
			this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioButton1.Checked = false;
			this.radioButton1.Location = new System.Drawing.Point(8, 344);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(176, 16);
			this.radioButton1.TabIndex = 13;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Fit by width";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioButton2.Location = new System.Drawing.Point(8, 368);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(176, 16);
			this.radioButton2.TabIndex = 14;
			this.radioButton2.Text = "Fit by height";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioButton3.Location = new System.Drawing.Point(8, 320);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(176, 16);
			this.radioButton3.TabIndex = 15;
			this.radioButton3.Text = "Fit To Screen";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// radioButton4
			// 
			this.radioButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioButton4.Checked = true;
			this.radioButton4.Location = new System.Drawing.Point(8, 296);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(176, 16);
			this.radioButton4.TabIndex = 16;
			this.radioButton4.Text = "Do not auto-fit";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			//this.Controls.Add(this.radioButton4);
			//this.Controls.Add(this.radioButton3);
			//this.Controls.Add(this.radioButton2);
			//this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.alvImageViewer1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.directoryViewer);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			
			 // Get the full path of your current directory
            string currentDirectoryPath = Directory.GetCurrentDirectory();
            // Get the parent directory of the current directory (i.e. the project directory)
            //string icoPath = Directory.GetParent(currentDirectoryPath).Parent.FullName + "\\app.ico";
            //this.Icon = new Icon(Resources.Myicon);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Image Browser ver 1.0.0";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
			
		}
	
		private void button1_Click(object sender, System.EventArgs e)
		{
			folderBrowserDialog1.SelectedPath = fullPath;
			folderBrowserDialog1.ShowDialog();
			if (folderBrowserDialog1.SelectedPath != null)
			{
				lblPath.Text = folderBrowserDialog1.SelectedPath;
				listBox1.Items.Clear();
				PopulateTreeView();
				//populateList("jpg");
				//populateList("bmp");
				//populateList("gif");
				//populateList("png");
				//populateList("tif");
				if (listBox1.Items.Count >= 1)
				{
					listBox1.SelectedIndex = 0;
				}
				else
				{
					listBox1.SelectedIndex = -1;
					//this.alvImageViewer1.ClearImage();
					//MessageBox.Show("No supported images in path");
				}
				//this.label1.Text = "Current Path : " + folderBrowserDialog1.SelectedPath ;
			}
		}
		
		private void PopulateTreeView()
		{
			this.alvImageViewer1.ClearImage();
			this.directoryViewer.Nodes.Clear();
			TreeNode rootNode;
		    DirectoryInfo info = new DirectoryInfo(folderBrowserDialog1.SelectedPath == "" ? "D:\\Code\\PHP\\uploads" : folderBrowserDialog1.SelectedPath);
		    if (info.Exists)
		    {
		        rootNode = new TreeNode(info.Name);
		        rootNode.Tag = info;
		        GetDirectories(info.GetDirectories(), rootNode);
		        this.directoryViewer.Nodes.Add(rootNode);
		    }
		    this.directoryViewer.ExpandAll();
		}
		
		private void GetDirectories(DirectoryInfo[] subDirs,
		    TreeNode nodeToAddTo)
		{
		
		    TreeNode aNode;
		
		    foreach (DirectoryInfo subDir in subDirs)
		    {
		        aNode = new TreeNode(subDir.Name, 0, 0);
		        aNode.Tag = subDir;
		        aNode.ImageKey = "folder";
		        try
		        {
		            if (subDir.GetDirectories().Length > 0)
		            {
		                GetDirectories(subDir.GetDirectories(), aNode);
		            }
		        }
		        catch (Exception ex)
		        {
		            Console.WriteLine(ex.Message);
		        }
		        finally
		        {
		            nodeToAddTo.Nodes.Add(aNode);
		        }
		    }
		}
		
		private void populateList(string FileExtension)
		{
			try
			{
				if(fullPath == "D:\\Code\\PHP\\uploads") return;
				string[] res = Directory.GetFiles(fullPath,"*." + FileExtension, SearchOption.AllDirectories);
				foreach(string path in res)
				{
					listBox1.Items.Add(path);
				}
			} catch (Exception) {
				
			}
		}
		
		private void directoryViewer_AfterSelect(object sender, TreeViewEventArgs e)
		{
		    // Get the currently selected node.
		    TreeNode selectedNode = directoryViewer.SelectedNode;
		    string parentPath = folderBrowserDialog1.SelectedPath == "" ? "D:\\Code\\PHP\\uploads" : folderBrowserDialog1.SelectedPath;
		    string curPath = directoryViewer.SelectedNode.FullPath;
		    char[] separator = { '\\' };
			string[] pathParms = curPath.Split(separator);
			string finalPath = parentPath + "\\";
			if(pathParms.Length > 1)
			{
				for(int i=1; i <  pathParms.Length-1;i++)
					finalPath += "\\" + pathParms[i];
			}
			fullPath = finalPath + "\\" + selectedNode.Text;
			listBox1.Items.Clear();
			populateList("jpg");
			populateList("bmp");
			populateList("gif");
			populateList("png");
			populateList("tif");	
			lblPath.Text = parentPath  + "       Image Count: " + listBox1.Items.Count;
		     //Update label text with the selected node's text value.
		    //label1.Text = directoryViewer.SelectedNode.Text;
		}

		
		// A method called when the selected index of a listbox changes
		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Checks if an item is currently selected in the listbox
			if (listBox1.SelectedIndex >= 0)
			{
				try {
					// Forces garbage collection to free up memory 
							// no longer being used by unreferenced objects
					GC.Collect();
		
					// Clears the current image displayed by alvImageViewer control
					alvImageViewer1.ClearImage();
							
					// Loads the corresponding image file to be displayed by passing it to ImageFromFile method of alvImageViewer control
					alvImageViewer1.ImageFromFile(
							listBox1.Items[listBox1.SelectedIndex].ToString()
						);
		
					// Updates the UI label to display the name of the currently selected image file
					label3.Text = "Current File Name: " + Path.GetFileName(listBox1.Items[listBox1.SelectedIndex].ToString());
		
					// Updates the UI label to display which page of the currently selected multipage image file is being displayed
					lblPage.Text = "Page " + alvImageViewer1.FrameCurrent + " of " + alvImageViewer1.FrameMax;
					
				} catch (Exception) {
					// Catches any exception that may occur while executing this function
					// and swallows it without doing anything; essentially ignores the error.
				} finally {
					// Any code here will execute after try block regardless whether exceptions were thrown or not.
					// There is no actual code in the finally block in this case.
				}
			}
		}
		
		
		private void listBox1_DoubleClick(object sender, EventArgs e)
		{
		    // Get the selected item
		    string selectedItem = (string)listBox1.SelectedItem;
		    System.Diagnostics.Process.Start(selectedItem );
		}



		#region "Image tricks"

		private void button2_Click(object sender, System.EventArgs e)
		{
			alvImageViewer1.Rotate90Left();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			alvImageViewer1.Rotate90Right();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			alvImageViewer1.FrameMoveTo(alvImageViewer1.FrameCurrent + 1);
			lblPage.Text = "Page " + alvImageViewer1.FrameCurrent + " of " + alvImageViewer1.FrameMax;
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			alvImageViewer1.FrameMoveTo(alvImageViewer1.FrameCurrent - 1);
			lblPage.Text = "Page " + alvImageViewer1.FrameCurrent + " of " + alvImageViewer1.FrameMax;
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			alvImageViewer1.FlipHorizontal();
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			alvImageViewer1.FlipVertical();
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			if (radioButton3.Checked == true)
			{
				MessageBox.Show("Pls. disable Auto Fit Image first.","Auto fit is active");
			}
			else
			{
				if (alvImageViewer1.ZoomRatio < 10)
				{
					alvImageViewer1.ZoomRatio = ((alvImageViewer1.ZoomRatio * 10) + 1)/10;
				}
			}
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			if (radioButton3.Checked == true)
			{
				MessageBox.Show("Pls. disable Auto Fit Image first.","Auto fit is active");
			}
			else
			{
				if (alvImageViewer1.ZoomRatio > 0.1)
				{
					alvImageViewer1.ZoomRatio = ((alvImageViewer1.ZoomRatio * 10) - 1)/10;
				}
			}
		}
		#endregion

		private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			alvImageViewer1.AutoFitToScreen = radioButton3.Checked;
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			alvImageViewer1.AutoFitToWidth = radioButton1.Checked;
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			alvImageViewer1.AutoFitToHeight = radioButton2.Checked;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.Text = "Top Image Vierwer ver. " + Application.ProductVersion;
			PopulateTreeView();
		}
		
	
	

	}
}
