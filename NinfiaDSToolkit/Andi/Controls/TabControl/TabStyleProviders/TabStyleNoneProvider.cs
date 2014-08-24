/*
 * This code is provided under the Code Project Open Licence (CPOL)
 * See http://www.codeproject.com/info/cpol10.aspx for details
 */

namespace NinfiaDSToolkit.Andi.Controls.TabControl.TabStyleProviders
{
    [System.ComponentModel.ToolboxItem(false)]
	public class TabStyleNoneProvider : AndiCustomTabStyleProvider
	{
		public TabStyleNoneProvider(AndiCustomTabControl tabControl) : base(tabControl){
		}
		
		public override void AddTabBorder(System.Drawing.Drawing2D.GraphicsPath path, System.Drawing.Rectangle tabBounds){
		}
	}
}
