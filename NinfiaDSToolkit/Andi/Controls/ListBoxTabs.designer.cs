namespace ListBoxTabs {
	partial class ListBoxTabs {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.m_listbox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// m_listbox
			// 
			this.m_listbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_listbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_listbox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.m_listbox.FormattingEnabled = true;
			this.m_listbox.IntegralHeight = false;
			this.m_listbox.Location = new System.Drawing.Point(0, 0);
			this.m_listbox.Name = "m_listbox";
			this.m_listbox.Size = new System.Drawing.Size(222, 251);
			this.m_listbox.TabIndex = 0;
			this.m_listbox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.m_listbox_DrawItem);
			this.m_listbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_listbox_MouseMove);
			// 
			// ListBoxTabs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_listbox);
			this.Name = "ListBoxTabs";
			this.Size = new System.Drawing.Size(222, 251);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox m_listbox;
	}
}
