## **Source Code repository for our EE464 Project.** ##

### Developers: ###
  * Jeffrey Sassen
  * Franco Alamo
  * Shyam Palaiyanur
  * Brandt Westing

#### Don't add any files to the repository that are not of the following extensions: ####
  * .resx
  * .cs
  * .bmp
  * .jpg

### Important: To test the program, one must edit the function Form1\_Load() in Form1.cs to look as follows: ###

```
private void Form1_Load(object sender, EventArgs e)
{            
   //wm.WiimoteChanged += new WiimoteChangedEventHandler(wm_WiimoteChanged);    

   //g = Graphics.FromImage(b);
   //wm.Connect();
   //wm.SetReportType(Wiimote.InputReport.IRAccel, true);
   //wm.SetLEDs(false, true, true, false);

}
```
