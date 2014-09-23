using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Andi.Controls {
	public partial class ListBoxTabs : UserControl {
		#region Members
		/// <summary>
		/// Bounds of the last-drawn item.
		/// </summary>
		Rectangle m_lastBounds = new Rectangle(0, 0, 0, 0);
		/// <summary>
		/// Index of the last-selected item.
		/// </summary>
		int m_lastIndex = -1;

		private int m_offset = 5;

		private Color m_unselectedBorderColor = SystemColors.Window;
		private Color m_unselectedBackColor = SystemColors.Window;
		private Color m_unselectedForeColor = SystemColors.WindowText;

		private Color m_selectedBorderColor = Color.FromArgb(255, 96, 161, 226);
		private Color m_selectedBackColor = Color.FromArgb(255, 180, 212, 244);
		private Color m_selectedForeColor = SystemColors.WindowText;

		private Color m_hoverBorderColor = Color.FromArgb(255, 120, 174, 229);
		private Color m_hoverBackColor = Color.FromArgb(255, 209, 226, 242);
		private Color m_hoverForeColor = SystemColors.WindowText;
		#endregion

		#region Properties
		/// <summary>
		/// Change the ListBox programmatically.
		/// </summary>
		[Browsable(false)]
		public ListBox ListBox {
			get { return m_listbox; }
		}

		[DefaultValue(5)]
		[Category("Appearance")]
		[Description("Gets or sets the offset for each ListBox item from its normal border (minimum is 1).")]
		public int BorderOffset {
			get { return m_offset; }
			set {
				if(value < 1) value = 1;
				m_offset = value;
			}
		}

		[Category("Appearance")]
		[Description("Gets or sets the border color for unselected ListBox items.")]
		public Color UnselectedBorderColor {
			get { return m_unselectedBorderColor; }
			set { m_unselectedBorderColor = value; }
		}

		[Category("Appearance")]
		[Description("Gets or sets the BackColor for unselected ListBox items.")]
		public Color UnselectedBackColor {
			get { return m_unselectedBackColor; }
			set { m_unselectedBackColor = value; }
		}

		[Category("Appearance")]
		[Description("Gets or sets the ForeColor for unselected ListBox items.")]
		public Color UnselectedForeColor {
			get { return m_unselectedForeColor; }
			set { m_unselectedForeColor = value; }
		}

		[Category("Appearance")]
		[Description("Gets or sets the border color for selected ListBox items.")]
		public Color SelectedBorderColor {
			get { return m_selectedBorderColor; }
			set { m_selectedBorderColor = value; }
		}

		[Category("Appearance")]
		[Description("Gets or sets the BackColor for selected ListBox items.")]
		public Color SelectedBackColor {
			get { return m_selectedBackColor; }
			set { m_selectedBackColor = value; }
		}

		[Category("Appearance")]
		[Description("Gets or sets the ForeColor for selected ListBox items.")]
		public Color SelectedForeColor {
			get { return m_selectedForeColor; }
			set { m_selectedForeColor = value; }
		}

		[Category("Appearance")]
		[Description("Gets or sets the border color for hovered-over ListBox items.")]
		public Color HoverBorderColor {
			get { return m_hoverBorderColor; }
			set { m_hoverBorderColor = value; }
		}

		[Category("Appearance")]
		[Description("Gets or sets the BackColor for hovered-over ListBox items.")]
		public Color HoverBackColor {
			get { return m_hoverBackColor; }
			set { m_hoverBackColor = value; }
		}

		[Category("Appearance")]
		[Description("Gets or sets the ForeColor for hovered-over ListBox items.")]
		public Color HoverForeColor {
			get { return m_hoverForeColor; }
			set { m_hoverForeColor = value; }
		}

		[Description("The background color of the ListBox.")]
		public override Color BackColor {
			get { return base.BackColor; }
			set {
				base.BackColor = value;
				m_listbox.BackColor = value;
			}
		}

		[Description("The foreground color of the ListBox, which is used to display text.")]
		public override Color ForeColor {
			get { return base.ForeColor; }
			set {
				base.ForeColor = value;
				m_listbox.ForeColor = value;
			}
		}

		[Description("The font used to display text in the ListBox.")]
		public override Font Font {
			get { return base.Font; }
			set {
				base.Font = value;
				m_listbox.Font = value;
			}
		}
		#endregion

		#region Methods
		public ListBoxTabs() {
			InitializeComponent();
		}

		private void m_listbox_Resize(object sender, EventArgs e) {
			m_lastIndex = -1;
			m_lastBounds = new Rectangle(0, 0, 0, 0);
			m_listbox.Invalidate();
		}

		private void m_listbox_DrawItem(object sender, DrawItemEventArgs e) {
			if(m_listbox.Items.Count > 0) {
				using(Graphics g = e.Graphics) {
					using(StringFormat sf = new StringFormat()) {
						Rectangle bounds = new Rectangle(
							e.Bounds.X + m_offset,
							e.Bounds.Y + m_offset,
							e.Bounds.Width - (m_offset * 2),
							e.Bounds.Height - (m_offset * 2)
						);
						sf.Alignment = StringAlignment.Center;
						sf.LineAlignment = StringAlignment.Center;

						// if the item is selected, redefine e and draw a box around it
						if((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
							bounds.Width = e.Bounds.Width - (m_offset * 2);
							bounds.Height = e.Bounds.Height - (m_offset * 2);

							e = new DrawItemEventArgs(
								g,
								e.Font,
								bounds,
								e.Index,
								e.State ^ DrawItemState.Selected,
								m_selectedForeColor,
								m_selectedBackColor
							);

							g.DrawRectangle(
								new Pen(m_selectedBorderColor),
								e.Bounds.X - 1,
								e.Bounds.Y - 1,
								e.Bounds.Width + 1,
								e.Bounds.Height + 1
							);
						}

						e.DrawBackground();
						// redraw the item name
						g.DrawString(m_listbox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, sf);
					}
				}
			}
		}

		private void m_listbox_MouseMove(object sender, MouseEventArgs e) {
			if(m_listbox.Items.Count > 0) {
				// get the index of the hovered item
				Point point = m_listbox.PointToClient(Cursor.Position);
				int index = m_listbox.IndexFromPoint(point);

				// if it's the same as the last item or no item, exit
				if(m_lastIndex == index || index < 0) return;

				using(Graphics g = m_listbox.CreateGraphics()) {
					using(StringFormat sf = new StringFormat()) {
						sf.Alignment = StringAlignment.Center;
						sf.LineAlignment = StringAlignment.Center;

						Rectangle bounds = m_listbox.GetItemRectangle(index);
						bounds = new Rectangle(
							bounds.X + m_offset - 1,
							bounds.Y + m_offset - 1,
							bounds.Width - (m_offset * 2) + 1,
							bounds.Height - (m_offset * 2) + 1
						);

						// If the item is unselected and not being hovered over, reset its colors
						if(m_lastBounds != bounds &&
							m_lastBounds.Width != 0 &&
							m_listbox.SelectedIndex != m_lastIndex) {
							DrawUnselected(g, sf);
						}

						// Color the hovered item
						if(m_listbox.SelectedIndex != index) {
							DrawHovered(g, bounds, sf, index);
						}

						// set these to the new item
						m_lastIndex = index;
						m_lastBounds = bounds;
					}
				}
			}
		}

		/// <summary>
		/// Redraws the unselected item.
		/// </summary>
		private void DrawUnselected(Graphics g, StringFormat sf) {
			// Draw the border
			g.DrawRectangle(new Pen(m_unselectedBorderColor), m_lastBounds);
			// Draw the inner rectangle
			g.FillRectangle(new SolidBrush(m_unselectedBackColor), m_lastBounds);
			// Redraw the text
			g.DrawString(m_listbox.Items[m_lastIndex].ToString(),
						 m_listbox.Font,
						 new SolidBrush(m_unselectedForeColor),
						 new Point(m_lastBounds.X + (m_lastBounds.Width / 2) + 1,
								   m_lastBounds.Y + (m_lastBounds.Height / 2) + 1),
								   sf);
		}

		/// <summary>
		/// Redraws the item being hovered over.
		/// </summary>
		/// <param name="g">The Graphics instance to work with.</param>
		/// <param name="bounds">The bounding rectangle around the item.</param>
		/// <param name="sf">The StringFormat instance used to draw the item's text.</param>
		/// <param name="index">The index of the item being hovered over.</param>
		private void DrawHovered(Graphics g, Rectangle bounds, StringFormat sf, int index) {
			// Draw the border
			g.DrawRectangle(new Pen(m_hoverBorderColor), bounds);
			// Draw the inner rectangle
			g.FillRectangle(new SolidBrush(m_hoverBackColor),
							bounds.X + 1, bounds.Y + 1, bounds.Width - 1, bounds.Height - 1);
			// Redraw the text
			g.DrawString(
				m_listbox.Items[index].ToString(),
				m_listbox.Font,
				new SolidBrush(m_hoverForeColor),
				new Point(bounds.X + (bounds.Width / 2) + 1, bounds.Y + (bounds.Height / 2) + 1),
				sf
			);
		}
		#endregion
	}
}
