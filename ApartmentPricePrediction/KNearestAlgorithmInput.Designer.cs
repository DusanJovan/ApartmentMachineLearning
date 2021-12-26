
using System.Windows.Forms;

namespace ApartmentPricePrediction
{
    partial class KNearestAlgorithmInput
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
            this.KParameterLabel = new System.Windows.Forms.Label();
            this.KParameter = new System.Windows.Forms.TextBox();
            this.DistanceFunctionLabel = new System.Windows.Forms.Label();
            this.distanceFunction = new System.Windows.Forms.ComboBox();
            this.MicroLocationLabel = new System.Windows.Forms.Label();
            this.microLocation = new System.Windows.Forms.ComboBox();
            this.AreaLabel = new System.Windows.Forms.Label();
            this.area = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yearType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.roomCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.story = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.heatType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.prediction = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.municipality = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.storyTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Terrace = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.parking = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.registrered = new System.Windows.Forms.ComboBox();
            this.classPrediction = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KParameterLabel
            // 
            this.KParameterLabel.AutoSize = true;
            this.KParameterLabel.Location = new System.Drawing.Point(34, 13);
            this.KParameterLabel.Name = "KParameterLabel";
            this.KParameterLabel.Size = new System.Drawing.Size(71, 15);
            this.KParameterLabel.TabIndex = 0;
            this.KParameterLabel.Text = "K parametar";
            // 
            // KParameter
            // 
            this.KParameter.Location = new System.Drawing.Point(257, 10);
            this.KParameter.Name = "KParameter";
            this.KParameter.Size = new System.Drawing.Size(126, 23);
            this.KParameter.TabIndex = 1;
            // 
            // DistanceFunctionLabel
            // 
            this.DistanceFunctionLabel.AutoSize = true;
            this.DistanceFunctionLabel.Location = new System.Drawing.Point(34, 49);
            this.DistanceFunctionLabel.Name = "DistanceFunctionLabel";
            this.DistanceFunctionLabel.Size = new System.Drawing.Size(105, 15);
            this.DistanceFunctionLabel.TabIndex = 2;
            this.DistanceFunctionLabel.Text = "Funkcija rastojanja";
            // 
            // distanceFunction
            // 
            this.distanceFunction.FormattingEnabled = true;
            this.distanceFunction.Location = new System.Drawing.Point(257, 46);
            this.distanceFunction.Name = "distanceFunction";
            this.distanceFunction.Size = new System.Drawing.Size(126, 23);
            this.distanceFunction.TabIndex = 3;
            // 
            // MicroLocationLabel
            // 
            this.MicroLocationLabel.AutoSize = true;
            this.MicroLocationLabel.Location = new System.Drawing.Point(34, 125);
            this.MicroLocationLabel.Name = "MicroLocationLabel";
            this.MicroLocationLabel.Size = new System.Drawing.Size(50, 15);
            this.MicroLocationLabel.TabIndex = 4;
            this.MicroLocationLabel.Text = "Lokacija";
            // 
            // microLocation
            // 
            this.microLocation.FormattingEnabled = true;
            this.microLocation.Location = new System.Drawing.Point(257, 122);
            this.microLocation.Name = "microLocation";
            this.microLocation.Size = new System.Drawing.Size(126, 23);
            this.microLocation.TabIndex = 5;
            // 
            // AreaLabel
            // 
            this.AreaLabel.AutoSize = true;
            this.AreaLabel.Location = new System.Drawing.Point(34, 163);
            this.AreaLabel.Name = "AreaLabel";
            this.AreaLabel.Size = new System.Drawing.Size(64, 15);
            this.AreaLabel.TabIndex = 6;
            this.AreaLabel.Text = "Kvadratura";
            // 
            // area
            // 
            this.area.Location = new System.Drawing.Point(257, 160);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(126, 23);
            this.area.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Novogradnja";
            // 
            // yearType
            // 
            this.yearType.FormattingEnabled = true;
            this.yearType.Location = new System.Drawing.Point(257, 199);
            this.yearType.Name = "yearType";
            this.yearType.Size = new System.Drawing.Size(126, 23);
            this.yearType.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Broj Soba";
            // 
            // roomCount
            // 
            this.roomCount.Location = new System.Drawing.Point(257, 236);
            this.roomCount.Name = "roomCount";
            this.roomCount.Size = new System.Drawing.Size(126, 23);
            this.roomCount.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sprat";
            // 
            // story
            // 
            this.story.Location = new System.Drawing.Point(257, 273);
            this.story.Name = "story";
            this.story.Size = new System.Drawing.Size(126, 23);
            this.story.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Grejanje";
            // 
            // heatType
            // 
            this.heatType.FormattingEnabled = true;
            this.heatType.Location = new System.Drawing.Point(257, 332);
            this.heatType.Name = "heatType";
            this.heatType.Size = new System.Drawing.Size(126, 23);
            this.heatType.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Izracunaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 520);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Predikcija";
            // 
            // prediction
            // 
            this.prediction.Enabled = false;
            this.prediction.Location = new System.Drawing.Point(257, 517);
            this.prediction.Name = "prediction";
            this.prediction.Size = new System.Drawing.Size(126, 23);
            this.prediction.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Opstina";
            // 
            // municipality
            // 
            this.municipality.FormattingEnabled = true;
            this.municipality.Location = new System.Drawing.Point(257, 90);
            this.municipality.Name = "municipality";
            this.municipality.Size = new System.Drawing.Size(126, 23);
            this.municipality.TabIndex = 22;
            this.municipality.SelectedIndexChanged += new System.EventHandler(this.municipality_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "____________________________________________________________________";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 495);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(347, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "____________________________________________________________________";
            // 
            // storyTotal
            // 
            this.storyTotal.Location = new System.Drawing.Point(257, 303);
            this.storyTotal.Name = "storyTotal";
            this.storyTotal.Size = new System.Drawing.Size(126, 23);
            this.storyTotal.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Spratova ukupno";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "Terasa";
            // 
            // Terrace
            // 
            this.Terrace.FormattingEnabled = true;
            this.Terrace.Location = new System.Drawing.Point(257, 363);
            this.Terrace.Name = "Terrace";
            this.Terrace.Size = new System.Drawing.Size(126, 23);
            this.Terrace.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 394);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 15);
            this.label11.TabIndex = 29;
            this.label11.Text = "Parking";
            // 
            // parking
            // 
            this.parking.FormattingEnabled = true;
            this.parking.Location = new System.Drawing.Point(257, 392);
            this.parking.Name = "parking";
            this.parking.Size = new System.Drawing.Size(126, 23);
            this.parking.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 430);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 31;
            this.label12.Text = "Uknjizen";
            // 
            // registrered
            // 
            this.registrered.FormattingEnabled = true;
            this.registrered.Location = new System.Drawing.Point(257, 427);
            this.registrered.Name = "registrered";
            this.registrered.Size = new System.Drawing.Size(126, 23);
            this.registrered.TabIndex = 32;
            // 
            // classPrediction
            // 
            this.classPrediction.Enabled = false;
            this.classPrediction.Location = new System.Drawing.Point(125, 517);
            this.classPrediction.Name = "classPrediction";
            this.classPrediction.Size = new System.Drawing.Size(126, 23);
            this.classPrediction.TabIndex = 33;
            // 
            // KNearestAlgorithmInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 564);
            this.Controls.Add(this.classPrediction);
            this.Controls.Add(this.registrered);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.parking);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Terrace);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.storyTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.municipality);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.prediction);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.heatType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.story);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.roomCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yearType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.area);
            this.Controls.Add(this.AreaLabel);
            this.Controls.Add(this.microLocation);
            this.Controls.Add(this.MicroLocationLabel);
            this.Controls.Add(this.distanceFunction);
            this.Controls.Add(this.DistanceFunctionLabel);
            this.Controls.Add(this.KParameter);
            this.Controls.Add(this.KParameterLabel);
            this.Name = "KNearestAlgorithmInput";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.KNearestAlgorithmInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label KParameterLabel;
        private TextBox KParameter;
        private Label DistanceFunctionLabel;
        private ComboBox distanceFunction;
        private Label MicroLocationLabel;
        private ComboBox microLocation;
        private Label AreaLabel;
        private TextBox area;
        private Label label1;
        private ComboBox yearType;
        private Label label2;
        private TextBox roomCount;
        private Label label3;
        private TextBox story;
        private Label label5;
        private ComboBox heatType;
        private Button button1;
        private Label label6;
        private TextBox prediction;
        private Label label7;
        private ComboBox municipality;
        private Label label4;
        private Label label8;
        private TextBox storyTotal;
        private Label label9;
        private Label label10;
        private ComboBox Terrace;
        private Label label11;
        private ComboBox parking;
        private Label label12;
        private ComboBox registrered;
        private TextBox classPrediction;
    }
}