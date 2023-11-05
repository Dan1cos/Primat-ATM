//using System;
//using System.ComponentModel;
//using System.Linq;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Input;
//using System.Windows.Media;

//namespace Primat_ATM.View.MControls
//{
//    [DefaultEvent("OnSelectedIndexChanged")]
//    class MComboBox : UserControl
//    {
//        //Fields
//        private SolidColorBrush background = new SolidColorBrush(Colors.WhiteSmoke);
//        private SolidColorBrush iconColor = new SolidColorBrush(Colors.MediumSlateBlue);
//        private SolidColorBrush listBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E6E4F5"));
//        private SolidColorBrush listTextColor = new SolidColorBrush(Colors.DimGray);
//        private SolidColorBrush borderColor = new SolidColorBrush(Colors.MediumSlateBlue);
//        private int borderSize = 1;

//        //Items
//        private ComboBox cmbList;
//        private Label lblText;
//        private Button btnIcon;

//        //Events
//        public event EventHandler OnSelectedIndexChanged;//Default event

//        //Constructor
//        public MComboBox()
//        {
//            cmbList = new ComboBox();
//            lblText = new Label();
//            btnIcon = new Button();
//            //this.SuspendLayout();////////////////////////////////////////////////////////////////////////////////////////////

//            //ComboBox: Dropdown list
//            cmbList.Background = listBackground;
//            cmbList.FontFamily = this.FontFamily;
//            cmbList.FontSize = this.FontSize;
//            cmbList.Foreground = listTextColor;
//            cmbList.SelectionChanged += new EventHandler(ComboBox_SelectedIndexChanged);//Default event
//            //cmbList.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);

//            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);//Refresh text
//            //cmbList.IsEditable = true;
//            //cmbList.TextChanged += new TextChangedEventHandler(ComboBox_TextChanged);


//            //Button: Icon
//            btnIcon.Dock = DockStyle.Right;
//            btnIcon.FlatStyle = FlatStyle.Flat;
//            btnIcon.FlatAppearance.BorderSize = 0;
//            btnIcon.BackColor = background;
//            btnIcon.Size = new Size(30, 30);
//            btnIcon.Cursor = Cursors.Hand;
//            btnIcon.Click += new EventHandler(Icon_Click);//Open dropdown list
//            btnIcon.Paint += new PaintEventHandler(Icon_Paint);//Draw icon

//            //Label: Text
//            lblText.Dock = DockStyle.Fill;
//            lblText.AutoSize = false;
//            lblText.BackColor = background;
//            lblText.TextAlign = ContentAlignment.MiddleLeft;
//            lblText.Padding = new Padding(8, 0, 0, 0);
//            lblText.Font = new Font(this.Font.Name, 10F);
//            //->Attach label events to user control event
//            lblText.Click += new EventHandler(Surface_Click);//Select combo box
//            lblText.MouseEnter += new EventHandler(Surface_MouseEnter);
//            lblText.MouseLeave += new EventHandler(Surface_MouseLeave);

//            //User Control
//            this.Controls.Add(lblText);//2
//            this.Controls.Add(btnIcon);//1
//            this.Controls.Add(cmbList);//0
//            this.MinimumSize = new Size(200, 30);
//            this.Size = new Size(200, 30);
//            this.ForeColor = Color.DimGray;
//            this.Padding = new Padding(borderSize);//Border Size
//            this.Font = new Font(this.Font.Name, 10F);
//            base.BackColor = borderColor; //Border Color
//            this.ResumeLayout();
//            AdjustComboBoxDimensions();
//        }

//        //Private methods
//        private void AdjustComboBoxDimensions()
//        {
//            cmbList.Width = lblText.Width;
//            //cmbList.Location = new Point()
//            //{
//            //    X = this.Width - this.Padding.Right - cmbList.Width,
//            //    Y = lblText.Bottom - cmbList.Height
//            //};
//            cmbList.HorizontalAlignment = HorizontalAlignment.Right;
//        }

//        //Event methods

//        //-> Default event
//        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (OnSelectedIndexChanged != null)
//                OnSelectedIndexChanged.Invoke(sender, e);
//            //Refresh text
//            lblText.Content = cmbList.Text;
//        }
//        //-> Items actions
//        private void Icon_Click(object sender, EventArgs e)
//        {
//            //Open dropdown list
//            cmbList.Select();
//            cmbList.DroppedDown = true;
//        }
//        private void Surface_Click(object sender, EventArgs e)
//        {
//            //Attach label click to user control click
//            this.OnClick(e);
//            //Select combo box
//            cmbList.Select();
//            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
//                cmbList.DroppedDown = true;//Open dropdown list
//        }
//        private void ComboBox_TextChanged(object sender, EventArgs e)
//        {
//            //Refresh text
//            lblText.Content = cmbList.Text;
//        }

//        //-> Draw icon
//        private void Icon_Paint(object sender, PaintEventArgs e)
//        {
//            //Fields
//            int iconWidht = 14;
//            int iconHeight = 6;
//            var rectIcon = new Rectangle((btnIcon.Width - iconWidht) / 2, (btnIcon.Height - iconHeight) / 2, iconWidht, iconHeight);
//            Graphics graph = e.Graphics;

//            //Draw arrow down icon
//            using (GraphicsPath path = new GraphicsPath())
//            using (Pen pen = new Pen(iconColor, 2))
//            {
//                graph.SmoothingMode = SmoothingMode.AntiAlias;
//                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidht / 2), rectIcon.Bottom);
//                path.AddLine(rectIcon.X + (iconWidht / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
//                graph.DrawPath(pen, path);
//            }
//        }

//        //Properties
//        //-> Appearance
//        [Category("M Code - Appearance")]
//        public new SolidColorBrush Background
//        {
//            get { return background; }
//            set
//            {
//                background = value;
//                lblText.Background = background;
//                btnIcon.Background = background;
//            }
//        }

//        [Category("M Code - Appearance")]
//        public SolidColorBrush IconColor
//        {
//            get { return iconColor; }
//            set
//            {
//                iconColor = value;
//                //btnIcon.Invalidate();//Redraw icon
//                //btnIcon.InvalidateVisual();
//            }
//        }

//        [Category("M Code - Appearance")]
//        public SolidColorBrush ListBackColor
//        {
//            get { return listBackground; }
//            set
//            {
//                listBackground = value;
//                cmbList.Background = listBackground;
//            }
//        }

//        [Category("M Code - Appearance")]
//        public SolidColorBrush ListTextColor
//        {
//            get { return listTextColor; }
//            set
//            {
//                listTextColor = value;
//                cmbList.Foreground = listTextColor;
//            }
//        }

//        [Category("M Code - Appearance")]
//        public SolidColorBrush BorderColor
//        {
//            get { return borderColor; }
//            set
//            {
//                borderColor = value;
//                base.Background = borderColor; //Border Color
//            }
//        }

//        [Category("M Code - Appearance")]
//        public int BorderSize
//        {
//            get { return borderSize; }
//            set
//            {
//                borderSize = value;
//                this.Padding = new Thickness(borderSize);//Border Size
//                AdjustComboBoxDimensions();
//            }
//        }

//        [Category("M Code - Appearance")]
//        public new Brush Foreground
//        {
//            get { return base.Foreground; }
//            set
//            {
//                base.Foreground = value;
//                lblText.Foreground = value;
//            }
//        }

//        [Category("M Code - Appearance")]
//        public new double FontSize
//        {
//            get { return base.FontSize; }
//            set
//            {
//                base.FontSize = value;
//                lblText.FontSize = value;
//                cmbList.FontSize = value;//Optional
//            }
//        }

//        [Category("M Code - Appearance")]
//        public new FontFamily FontFamily
//        {
//            get { return base.FontFamily; }
//            set
//            {
//                base.FontFamily = value;
//                lblText.FontFamily = value;
//                cmbList.FontFamily = value;//Optional
//            }
//        }

//        [Category("M Code - Appearance")]
//        public string Texts
//        {
//            get { return (string)lblText.Content; }
//            set { lblText.Content = value; }
//        }

//        [Category("M Code - Appearance")]
//        public ComboBoxStyle DropDownStyle
//        {
//            get { return cmbList.DropDownStyle; }
//            set
//            {
//                if (cmbList.DropDownStyle != ComboBoxStyle.Simple)
//                    cmbList.DropDownStyle = value;
//            }
//        }

//        //Properties
//        //-> Data
//        [Category("M Code - Data")]
//        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
//        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
//        [Localizable(true)]
//        [MergableProperty(false)]
//        public ComboBox.ObjectCollection Items
//        {
//            get { return cmbList.Items; }
//        }

//        [Category("M Code - Data")]
//        [AttributeProvider(typeof(IListSource))]
//        [DefaultValue(null)]
//        public object DataSource
//        {
//            get { return cmbList.DataSource; }
//            set { cmbList.DataSource = value; }
//        }

//        [Category("M Code - Data")]
//        [Browsable(true)]
//        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
//        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
//        [EditorBrowsable(EditorBrowsableState.Always)]
//        [Localizable(true)]
//        public AutoCompleteStringCollection AutoCompleteCustomSource
//        {
//            get { return cmbList.AutoCompleteCustomSource; }
//            set { cmbList.AutoCompleteCustomSource = value; }
//        }

//        [Category("M Code - Data")]
//        [Browsable(true)]
//        [DefaultValue(AutoCompleteSource.None)]
//        [EditorBrowsable(EditorBrowsableState.Always)]
//        public AutoCompleteSource AutoCompleteSource
//        {
//            get { return cmbList.AutoCompleteSource; }
//            set { cmbList.AutoCompleteSource = value; }
//        }

//        [Category("M Code - Data")]
//        [Browsable(true)]
//        [DefaultValue(AutoCompleteMode.None)]
//        [EditorBrowsable(EditorBrowsableState.Always)]
//        public AutoCompleteMode AutoCompleteMode
//        {
//            get { return cmbList.AutoCompleteMode; }
//            set { cmbList.AutoCompleteMode = value; }
//        }

//        [Category("M Code - Data")]
//        [Bindable(true)]
//        [Browsable(false)]
//        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
//        public object SelectedItem
//        {
//            get { return cmbList.SelectedItem; }
//            set { cmbList.SelectedItem = value; }
//        }

//        [Category("M Code - Data")]
//        [Browsable(false)]
//        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
//        public int SelectedIndex
//        {
//            get { return cmbList.SelectedIndex; }
//            set { cmbList.SelectedIndex = value; }
//        }

//        [Category("M Code - Data")]
//        [DefaultValue("")]
//        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
//        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
//        public string DisplayMember
//        {
//            get { return cmbList.DisplayMember; }
//            set { cmbList.DisplayMember = value; }
//        }

//        [Category("M Code - Data")]
//        [DefaultValue("")]
//        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
//        public string ValueMember
//        {
//            get { return cmbList.ValueMember; }
//            set { cmbList.ValueMember = value; }
//        }

//        //->Attach label events to user control event
//        private void Surface_MouseLeave(object sender, EventArgs e)
//        {
//            this.OnMouseLeave(e);
//        }

//        private void Surface_MouseEnter(object sender, EventArgs e)
//        {
//            this.OnMouseEnter(e);
//        }
//        //::::+

//        //Overridden methods
//        protected override void OnResize(EventArgs e)
//        {
//            base.OnResize(e);
//            AdjustComboBoxDimensions();
//        }
//    }
//}
