#region MIT

// 
// GMare.
// Copyright (C) 2011 Michael Mercado
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GMare.Controls
{
    /// <summary>
    /// Overrides the default blue XP style.
    /// </summary>
    class VisualStyle : ProfessionalColorTable
    {
        #region Fields

        public static bool UserStyle = false;

        #endregion

        #region Overrides

        #region Style: Button

        public override Color ButtonCheckedGradientBegin
        {
            get
            {
                return Color.FromArgb(0xC1, 210, 0xEE);
            }
        }

        public override Color ButtonCheckedGradientEnd
        {
            get
            {
                return Color.FromArgb(0xC1, 210, 0xEE);
            }
        }

        public override Color ButtonCheckedGradientMiddle
        {
            get
            {
                return Color.FromArgb(0xC1, 210, 0xEE);
            }
        }

        public override Color ButtonPressedBorder
        {
            get
            {
                return Color.FromArgb(0x31, 0x6A, 0xC5);
            }
        }

        public override Color ButtonPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(0x98, 0xB5, 0xE2);
            }
        }

        public override Color ButtonPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(0x98, 0xB5, 0xE2);
            }
        }

        public override Color ButtonPressedGradientMiddle
        {
            get
            {
                return Color.FromArgb(0x98, 0xB5, 0xE2);
            }
        }

        public override Color ButtonSelectedBorder
        {
            get
            {
                return SystemColors.MenuHighlight;
            }
        }

        public override Color ButtonSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(0xC1, 210, 0xEE);
            }
        }

        public override Color ButtonSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(0xC1, 210, 0xEE);
            }
        }

        public override Color ButtonSelectedGradientMiddle
        {
            get
            {
                return Color.FromArgb(0xC1, 210, 0xEE);
            }
        }

        public override Color CheckBackground
        {
            get
            {
                return Color.FromArgb(0xE1, 230, 0xE8);
            }
        }

        public override Color CheckPressedBackground
        {
            get
            {
                return Color.FromArgb(0x31, 0x6A, 0xC5);
            }
        }

        public override Color CheckSelectedBackground
        {
            get
            {
                return Color.FromArgb(0x31, 0x6A, 0xC5);
            }
        }

        public override Color GripDark
        {
            get
            {
                return Color.FromArgb(0xC1, 190, 0xB3);
            }
        }

        public override Color GripLight
        {
            get
            {
                return Color.FromArgb(0xFF, 0xFF, 0xFF);
            }
        }

        #endregion

        #region Style: Image Margin

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.FromArgb(251, 250, 247);
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(0xBD, 0xBD, 0xA3);
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.FromArgb(0xEC, 0xE7, 0xE0);
            }
        }

        public override Color ImageMarginRevealedGradientBegin
        {
            get
            {
                return Color.FromArgb(0xF7, 0xF6, 0xEF);
            }
        }

        public override Color ImageMarginRevealedGradientEnd
        {
            get
            {
                return Color.FromArgb(230, 0xE3, 210);
            }
        }

        public override Color ImageMarginRevealedGradientMiddle
        {
            get
            {
                return Color.FromArgb(0xF2, 240, 0xE4);
            }
        }

        #endregion

        #region Style: Menu Item
        
        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(138, 134, 122);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return SystemColors.MenuHighlight;
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(252, 252, 249);
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(252, 252, 249);
            }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get
            {
                return Color.FromArgb(252, 252, 249);
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(0xC1, 210, 0xEE);
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(0xC1, 210, 0xEE);
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(0xC1, 210, 0xEE);
            }
        }

        #endregion

        #region Style: Menu Strip / Tool Strip

        public override Color MenuStripGradientBegin
        {
            get { return Color.FromArgb(0xE5, 0xE5, 0xD7); }
        }

        public override Color MenuStripGradientEnd
        {
            get { return Color.FromArgb(0xF4, 0xF2, 0xE8); }
        }

        public override Color OverflowButtonGradientBegin
        {
            get { return Color.FromArgb(0xF3, 0xF2, 240); }
        }

        public override Color OverflowButtonGradientEnd
        {
            get { return Color.FromArgb(0x92, 0x92, 0x76); }
        }

        public override Color OverflowButtonGradientMiddle
        {
            get { return Color.FromArgb(0xE2, 0xE1, 0xDB); }
        }

        public override Color RaftingContainerGradientBegin
        {
            get { return Color.FromArgb(0xE5, 0xE5, 0xD7); }
        }

        public override Color RaftingContainerGradientEnd
        {
            get { return Color.FromArgb(0xF4, 0xF2, 0xE8); }
        }

        public override Color SeparatorDark
        {
            get { return Color.FromArgb(0xC5, 0xC2, 0xB8); }
        }

        public override Color SeparatorLight
        {
            get { return Color.FromArgb(0xFF, 0xFF, 0xFF); }
        }

        public override Color ToolStripBorder
        {
            get { return Color.FromArgb(0xA3, 0xA3, 0x7C); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(0xFC, 0xFC, 0xF9); }
        }

        public override Color ToolStripGradientBegin
        {
            get { return Color.FromArgb(0xF7, 0xF6, 0xEF); }
        }

        public override Color ToolStripGradientEnd
        {
            get { return Color.FromArgb(192, 192, 168); }
        }

        public override Color ToolStripGradientMiddle
        {
            get { return Color.FromArgb(0xF2, 240, 0xE4); }
        }

        public override Color ToolStripPanelGradientBegin
        {
            get { return Color.FromArgb(0xE5, 0xE5, 0xD7); }
        }

        public override Color ToolStripPanelGradientEnd
        {
            get { return Color.FromArgb(0xF4, 0xF2, 0xE8); }
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Static method to apply visual style through out the application.
        /// </summary>
        public static void ApplyVisualStyle()
        {
            if (VisualStyleInformation.ColorScheme == "NormalColor" &&
                VisualStyleInformation.DisplayName == "Windows XP style" &&
                VisualStyleInformation.Company == "Microsoft Corporation")
            {
                ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new VisualStyle());
                VisualStyle.UserStyle = true;
            }

            ((ToolStripProfessionalRenderer)ToolStripManager.Renderer).RoundedEdges = false;
        }

        #endregion
    }
}