namespace Controle
{
    partial class Selecteur
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.barreDéfilement = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // barreDéfilement
            // 
            this.barreDéfilement.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barreDéfilement.Location = new System.Drawing.Point(0, 139);
            this.barreDéfilement.Name = "barreDéfilement";
            this.barreDéfilement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.barreDéfilement.Size = new System.Drawing.Size(150, 17);
            this.barreDéfilement.TabIndex = 0;
            this.barreDéfilement.Scroll += new System.Windows.Forms.ScrollEventHandler(this.défilement);
            // 
            // Selecteur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barreDéfilement);
            this.DoubleBuffered = true;
            this.Name = "Selecteur";
            this.Size = new System.Drawing.Size(150, 156);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Selecteur_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Selecteur_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar barreDéfilement;
    }
}
