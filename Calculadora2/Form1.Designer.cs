namespace Calculadora2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.operacionTxT = new System.Windows.Forms.TextBox();
            this.btIgual = new System.Windows.Forms.Button();
            this.btSuma = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btResta = new System.Windows.Forms.Button();
            this.btMultiplicacion = new System.Windows.Forms.Button();
            this.btDivision = new System.Windows.Forms.Button();
            this.bt7 = new System.Windows.Forms.Button();
            this.bt8 = new System.Windows.Forms.Button();
            this.bt9 = new System.Windows.Forms.Button();
            this.btExponente = new System.Windows.Forms.Button();
            this.bt4 = new System.Windows.Forms.Button();
            this.bt5 = new System.Windows.Forms.Button();
            this.bt6 = new System.Windows.Forms.Button();
            this.btRaiz = new System.Windows.Forms.Button();
            this.bt1 = new System.Windows.Forms.Button();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt3 = new System.Windows.Forms.Button();
            this.btComa = new System.Windows.Forms.Button();
            this.bt0 = new System.Windows.Forms.Button();
            this.btBorrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // operacionTxT
            // 
            this.operacionTxT.BackColor = System.Drawing.Color.White;
            this.operacionTxT.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operacionTxT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.operacionTxT.Location = new System.Drawing.Point(23, 25);
            this.operacionTxT.Multiline = true;
            this.operacionTxT.Name = "operacionTxT";
            this.operacionTxT.Size = new System.Drawing.Size(295, 75);
            this.operacionTxT.TabIndex = 1;
            this.operacionTxT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btIgual
            // 
            this.btIgual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btIgual.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIgual.ForeColor = System.Drawing.Color.White;
            this.btIgual.Location = new System.Drawing.Point(248, 347);
            this.btIgual.Name = "btIgual";
            this.btIgual.Size = new System.Drawing.Size(70, 149);
            this.btIgual.TabIndex = 2;
            this.btIgual.Text = "=";
            this.btIgual.UseVisualStyleBackColor = false;
            this.btIgual.Click += new System.EventHandler(this.btIgual_Click);
            // 
            // btSuma
            // 
            this.btSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSuma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btSuma.Location = new System.Drawing.Point(20, 119);
            this.btSuma.Name = "btSuma";
            this.btSuma.Size = new System.Drawing.Size(70, 70);
            this.btSuma.TabIndex = 4;
            this.btSuma.Text = "+";
            this.btSuma.UseVisualStyleBackColor = true;
            this.btSuma.Click += new System.EventHandler(this.btSuma_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(134, 156);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(0, 0);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btResta
            // 
            this.btResta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btResta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btResta.Location = new System.Drawing.Point(96, 119);
            this.btResta.Name = "btResta";
            this.btResta.Size = new System.Drawing.Size(70, 70);
            this.btResta.TabIndex = 6;
            this.btResta.Text = "-";
            this.btResta.UseVisualStyleBackColor = true;
            this.btResta.Click += new System.EventHandler(this.btResta_Click);
            // 
            // btMultiplicacion
            // 
            this.btMultiplicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMultiplicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btMultiplicacion.Location = new System.Drawing.Point(172, 119);
            this.btMultiplicacion.Name = "btMultiplicacion";
            this.btMultiplicacion.Size = new System.Drawing.Size(70, 70);
            this.btMultiplicacion.TabIndex = 7;
            this.btMultiplicacion.Text = "*";
            this.btMultiplicacion.UseVisualStyleBackColor = true;
            this.btMultiplicacion.Click += new System.EventHandler(this.btMultiplicacion_Click);
            // 
            // btDivision
            // 
            this.btDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDivision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btDivision.Location = new System.Drawing.Point(248, 119);
            this.btDivision.Name = "btDivision";
            this.btDivision.Size = new System.Drawing.Size(70, 72);
            this.btDivision.TabIndex = 8;
            this.btDivision.Text = "/";
            this.btDivision.UseVisualStyleBackColor = true;
            this.btDivision.Click += new System.EventHandler(this.btDivision_Click);
            // 
            // bt7
            // 
            this.bt7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt7.Location = new System.Drawing.Point(20, 195);
            this.bt7.Name = "bt7";
            this.bt7.Size = new System.Drawing.Size(70, 70);
            this.bt7.TabIndex = 9;
            this.bt7.Text = "7";
            this.bt7.UseVisualStyleBackColor = true;
            this.bt7.Click += new System.EventHandler(this.bt7_Click);
            // 
            // bt8
            // 
            this.bt8.BackColor = System.Drawing.Color.White;
            this.bt8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt8.Location = new System.Drawing.Point(96, 195);
            this.bt8.Name = "bt8";
            this.bt8.Size = new System.Drawing.Size(70, 70);
            this.bt8.TabIndex = 10;
            this.bt8.Text = "8";
            this.bt8.UseVisualStyleBackColor = false;
            this.bt8.Click += new System.EventHandler(this.bt8_Click);
            // 
            // bt9
            // 
            this.bt9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt9.Location = new System.Drawing.Point(172, 195);
            this.bt9.Name = "bt9";
            this.bt9.Size = new System.Drawing.Size(70, 70);
            this.bt9.TabIndex = 11;
            this.bt9.Text = "9";
            this.bt9.UseVisualStyleBackColor = true;
            this.bt9.Click += new System.EventHandler(this.bt9_Click);
            // 
            // btExponente
            // 
            this.btExponente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExponente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btExponente.Location = new System.Drawing.Point(248, 195);
            this.btExponente.Name = "btExponente";
            this.btExponente.Size = new System.Drawing.Size(70, 70);
            this.btExponente.TabIndex = 12;
            this.btExponente.Text = "^";
            this.btExponente.UseVisualStyleBackColor = true;
            this.btExponente.Click += new System.EventHandler(this.btExponente_Click);
            // 
            // bt4
            // 
            this.bt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt4.Location = new System.Drawing.Point(23, 271);
            this.bt4.Name = "bt4";
            this.bt4.Size = new System.Drawing.Size(70, 70);
            this.bt4.TabIndex = 13;
            this.bt4.Text = "4";
            this.bt4.UseVisualStyleBackColor = true;
            this.bt4.Click += new System.EventHandler(this.bt4_Click);
            // 
            // bt5
            // 
            this.bt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt5.Location = new System.Drawing.Point(99, 271);
            this.bt5.Name = "bt5";
            this.bt5.Size = new System.Drawing.Size(70, 70);
            this.bt5.TabIndex = 14;
            this.bt5.Text = "5";
            this.bt5.UseVisualStyleBackColor = true;
            this.bt5.Click += new System.EventHandler(this.bt5_Click);
            // 
            // bt6
            // 
            this.bt6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt6.Location = new System.Drawing.Point(172, 271);
            this.bt6.Name = "bt6";
            this.bt6.Size = new System.Drawing.Size(70, 70);
            this.bt6.TabIndex = 15;
            this.bt6.Text = "6";
            this.bt6.UseVisualStyleBackColor = true;
            this.bt6.Click += new System.EventHandler(this.bt6_Click);
            // 
            // btRaiz
            // 
            this.btRaiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRaiz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btRaiz.Location = new System.Drawing.Point(248, 271);
            this.btRaiz.Name = "btRaiz";
            this.btRaiz.Size = new System.Drawing.Size(70, 70);
            this.btRaiz.TabIndex = 16;
            this.btRaiz.Text = "√";
            this.btRaiz.UseVisualStyleBackColor = true;
            this.btRaiz.Click += new System.EventHandler(this.btRaiz_Click);
            // 
            // bt1
            // 
            this.bt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt1.Location = new System.Drawing.Point(23, 347);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(70, 70);
            this.bt1.TabIndex = 17;
            this.bt1.Text = "1";
            this.bt1.UseVisualStyleBackColor = true;
            this.bt1.Click += new System.EventHandler(this.bt1_Click);
            // 
            // bt2
            // 
            this.bt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt2.Location = new System.Drawing.Point(99, 347);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(70, 70);
            this.bt2.TabIndex = 18;
            this.bt2.Text = "2";
            this.bt2.UseVisualStyleBackColor = true;
            this.bt2.Click += new System.EventHandler(this.bt2_Click);
            // 
            // bt3
            // 
            this.bt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt3.Location = new System.Drawing.Point(172, 347);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(70, 70);
            this.bt3.TabIndex = 19;
            this.bt3.Text = "3";
            this.bt3.UseVisualStyleBackColor = true;
            this.bt3.Click += new System.EventHandler(this.bt3_Click);
            // 
            // btComa
            // 
            this.btComa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btComa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btComa.Location = new System.Drawing.Point(172, 423);
            this.btComa.Name = "btComa";
            this.btComa.Size = new System.Drawing.Size(70, 70);
            this.btComa.TabIndex = 20;
            this.btComa.Text = ".";
            this.btComa.UseVisualStyleBackColor = true;
            this.btComa.Click += new System.EventHandler(this.btComa_Click);
            // 
            // bt0
            // 
            this.bt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bt0.Location = new System.Drawing.Point(99, 423);
            this.bt0.Name = "bt0";
            this.bt0.Size = new System.Drawing.Size(70, 70);
            this.bt0.TabIndex = 21;
            this.bt0.Text = "0";
            this.bt0.UseVisualStyleBackColor = true;
            this.bt0.Click += new System.EventHandler(this.bt0_Click);
            // 
            // btBorrar
            // 
            this.btBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBorrar.ForeColor = System.Drawing.Color.White;
            this.btBorrar.Location = new System.Drawing.Point(23, 423);
            this.btBorrar.Name = "btBorrar";
            this.btBorrar.Size = new System.Drawing.Size(70, 70);
            this.btBorrar.TabIndex = 22;
            this.btBorrar.Text = "CE";
            this.btBorrar.UseVisualStyleBackColor = false;
            this.btBorrar.Click += new System.EventHandler(this.btBorrar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(345, 511);
            this.Controls.Add(this.btBorrar);
            this.Controls.Add(this.bt0);
            this.Controls.Add(this.btComa);
            this.Controls.Add(this.bt3);
            this.Controls.Add(this.bt2);
            this.Controls.Add(this.bt1);
            this.Controls.Add(this.btRaiz);
            this.Controls.Add(this.bt6);
            this.Controls.Add(this.bt5);
            this.Controls.Add(this.bt4);
            this.Controls.Add(this.btExponente);
            this.Controls.Add(this.bt9);
            this.Controls.Add(this.bt8);
            this.Controls.Add(this.bt7);
            this.Controls.Add(this.btDivision);
            this.Controls.Add(this.btMultiplicacion);
            this.Controls.Add(this.btResta);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btSuma);
            this.Controls.Add(this.btIgual);
            this.Controls.Add(this.operacionTxT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox operacionTxT;
        private System.Windows.Forms.Button btIgual;
        private System.Windows.Forms.Button btSuma;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btResta;
        private System.Windows.Forms.Button btMultiplicacion;
        private System.Windows.Forms.Button btDivision;
        private System.Windows.Forms.Button bt7;
        private System.Windows.Forms.Button bt8;
        private System.Windows.Forms.Button bt9;
        private System.Windows.Forms.Button btExponente;
        private System.Windows.Forms.Button bt4;
        private System.Windows.Forms.Button bt5;
        private System.Windows.Forms.Button bt6;
        private System.Windows.Forms.Button btRaiz;
        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt3;
        private System.Windows.Forms.Button btComa;
        private System.Windows.Forms.Button bt0;
        private System.Windows.Forms.Button btBorrar;
    }
}

