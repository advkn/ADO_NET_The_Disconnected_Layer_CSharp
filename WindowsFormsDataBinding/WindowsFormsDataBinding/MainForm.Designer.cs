﻿namespace WindowsFormsDataBinding
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.carInventoryGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCarToRemove = new System.Windows.Forms.TextBox();
            this.btnRemoveCar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMakeToView = new System.Windows.Forms.TextBox();
            this.btnDisplayMakes = new System.Windows.Forms.Button();
            this.btnChangeMakes = new System.Windows.Forms.Button();
            this.dataGridYugosView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).BeginInit();
            this.SuspendLayout();
            // 
            // carInventoryGridView
            // 
            this.carInventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carInventoryGridView.Location = new System.Drawing.Point(12, 44);
            this.carInventoryGridView.Name = "carInventoryGridView";
            this.carInventoryGridView.Size = new System.Drawing.Size(606, 328);
            this.carInventoryGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Here\'s what we have in stock";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveCar);
            this.groupBox1.Controls.Add(this.txtCarToRemove);
            this.groupBox1.Location = new System.Drawing.Point(12, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter ID of Car to Delete";
            // 
            // txtCarToRemove
            // 
            this.txtCarToRemove.Location = new System.Drawing.Point(7, 30);
            this.txtCarToRemove.Name = "txtCarToRemove";
            this.txtCarToRemove.Size = new System.Drawing.Size(100, 20);
            this.txtCarToRemove.TabIndex = 0;
            // 
            // btnRemoveCar
            // 
            this.btnRemoveCar.Location = new System.Drawing.Point(113, 27);
            this.btnRemoveCar.Name = "btnRemoveCar";
            this.btnRemoveCar.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCar.TabIndex = 1;
            this.btnRemoveCar.Text = "Delete!";
            this.btnRemoveCar.UseVisualStyleBackColor = true;
            this.btnRemoveCar.Click += new System.EventHandler(this.btnRemoveCar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDisplayMakes);
            this.groupBox2.Controls.Add(this.txtMakeToView);
            this.groupBox2.Location = new System.Drawing.Point(311, 394);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enter Make to View";
            // 
            // txtMakeToView
            // 
            this.txtMakeToView.Location = new System.Drawing.Point(7, 30);
            this.txtMakeToView.Name = "txtMakeToView";
            this.txtMakeToView.Size = new System.Drawing.Size(100, 20);
            this.txtMakeToView.TabIndex = 0;
            // 
            // btnDisplayMakes
            // 
            this.btnDisplayMakes.Location = new System.Drawing.Point(114, 30);
            this.btnDisplayMakes.Name = "btnDisplayMakes";
            this.btnDisplayMakes.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayMakes.TabIndex = 1;
            this.btnDisplayMakes.Text = "View!";
            this.btnDisplayMakes.UseVisualStyleBackColor = true;
            this.btnDisplayMakes.Click += new System.EventHandler(this.btnDisplayMakes_Click);
            // 
            // btnChangeMakes
            // 
            this.btnChangeMakes.Location = new System.Drawing.Point(452, 13);
            this.btnChangeMakes.Name = "btnChangeMakes";
            this.btnChangeMakes.Size = new System.Drawing.Size(166, 23);
            this.btnChangeMakes.TabIndex = 4;
            this.btnChangeMakes.Text = "Change all BMWs to Yugos";
            this.btnChangeMakes.UseVisualStyleBackColor = true;
            this.btnChangeMakes.Click += new System.EventHandler(this.btnChangeMakes_Click);
            // 
            // dataGridYugosView
            // 
            this.dataGridYugosView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridYugosView.Location = new System.Drawing.Point(12, 545);
            this.dataGridYugosView.Name = "dataGridYugosView";
            this.dataGridYugosView.Size = new System.Drawing.Size(606, 150);
            this.dataGridYugosView.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Yugos Only";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 706);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridYugosView);
            this.Controls.Add(this.btnChangeMakes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.carInventoryGridView);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView carInventoryGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveCar;
        private System.Windows.Forms.TextBox txtCarToRemove;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDisplayMakes;
        private System.Windows.Forms.TextBox txtMakeToView;
        private System.Windows.Forms.Button btnChangeMakes;
        private System.Windows.Forms.DataGridView dataGridYugosView;
        private System.Windows.Forms.Label label2;
    }
}

