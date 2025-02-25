﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
namespace DotNetNuke.Web.UI.WebControls
{
    using System;
    using System.ComponentModel;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DotNetNuke.Services.Localization;

    public class DnnTextLink : WebControl, ILocalizable
    {
        private bool localize = true;
        private HyperLink textHyperlinkControl;

        /// <summary>Initializes a new instance of the <see cref="DnnTextLink"/> class.</summary>
        public DnnTextLink()
            : base("span")
        {
            this.CssClass = "dnnTextLink";
            this.DisabledCssClass = "dnnTextLink disabled";
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                return this.TextHyperlinkControl.Text;
            }

            set
            {
                this.TextHyperlinkControl.Text = value;
            }
        }

        /// <inheritdoc/>
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public override string ToolTip
        {
            get
            {
                return this.TextHyperlinkControl.ToolTip;
            }

            set
            {
                this.TextHyperlinkControl.ToolTip = value;
            }
        }

        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("")]
        [Localizable(true)]
        public string NavigateUrl
        {
            get
            {
                return this.TextHyperlinkControl.NavigateUrl;
            }

            set
            {
                this.TextHyperlinkControl.NavigateUrl = value;
            }
        }

        [Bindable(true)]
        [Category("Behavior")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Target
        {
            get
            {
                return this.TextHyperlinkControl.Target;
            }

            set
            {
                this.TextHyperlinkControl.Target = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public new string DisabledCssClass
        {
            get
            {
                return this.ViewState["DisabledCssClass"] == null ? string.Empty : (string)this.ViewState["DisabledCssClass"];
            }

            set
            {
                this.ViewState["DisabledCssClass"] = value;
            }
        }

        /// <inheritdoc/>
        public bool Localize
        {
            get
            {
                return this.localize;
            }

            set
            {
                this.localize = value;
            }
        }

        /// <inheritdoc/>
        public string LocalResourceFile { get; set; }

        private HyperLink TextHyperlinkControl
        {
            get
            {
                if (this.textHyperlinkControl == null)
                {
                    this.textHyperlinkControl = new HyperLink();
                }

                return this.textHyperlinkControl;
            }
        }

        /// <inheritdoc/>
        public virtual void LocalizeStrings()
        {
            if (this.Localize)
            {
                if (!string.IsNullOrEmpty(this.ToolTip))
                {
                    this.ToolTip = Localization.GetString(this.ToolTip, this.LocalResourceFile);
                }

                if (!string.IsNullOrEmpty(this.Text))
                {
                    this.Text = Localization.GetString(this.Text, this.LocalResourceFile);

                    if (string.IsNullOrEmpty(this.ToolTip))
                    {
                        this.ToolTip = Localization.GetString(string.Format("{0}.ToolTip", this.Text), this.LocalResourceFile);
                    }

                    if (string.IsNullOrEmpty(this.ToolTip))
                    {
                        this.ToolTip = this.Text;
                    }
                }
            }
        }

        /// <inheritdoc/>
        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            this.Controls.Add(this.TextHyperlinkControl);
        }

        /// <inheritdoc/>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.LocalResourceFile = Utilities.GetLocalResourceFile(this);
        }

        /// <inheritdoc/>
        protected override void Render(HtmlTextWriter writer)
        {
            this.LocalizeStrings();

            if (!this.Enabled)
            {
                if (!string.IsNullOrEmpty(this.DisabledCssClass))
                {
                    this.CssClass = this.DisabledCssClass;
                }

                this.NavigateUrl = "javascript:void(0);";
            }

            this.RenderBeginTag(writer);
            this.RenderChildren(writer);
            this.RenderEndTag(writer);
        }
    }
}
