using UnityEngine;
using System.IO.Ports;
using System;

// This class manages all input from the controller and provides interfaces to access the data.
public class Controller : MonoBehaviour {

	// the serial port
	public String serialPort = "/dev/cu.usbmodem1421";

	// the input stream
	private SerialPort inputStream;

	/**
	* Bit masks for buttons.
	**/
	public static readonly int button01 = 0x040;
	public static readonly int button02 = 0x080;
	public static readonly int button03 = 0x100;
	public static readonly int button04 = 0x200;
	public static readonly int button05 = 0x400;
	public static readonly int button06 = 0x800;

	/**
	 * current state of the LEDs
	 **/
	private bool LED1 = false;
	private bool LED2 = false;
	private bool LED3 = false;
	private bool LED4 = false;

	/**
	 * current state of the Rumble motor
	 **/
	private int rumbleMotor = 0;

	/**
	 * raw data of the analog signal
	 **/
	private string analogRawData;

	/**
	 * raw data of the accelerometer.
	 **/
	private string accelerometerRawData;

	// private constructor
	public Controller() {
		inputStream = new SerialPort(serialPort, 115200);
		inputStream.Open();
		Debug.Log("Serial port opened");
	}

	// Returns the bit mask of the buttons
	private Int32 getButtons() {
		inputStream.Write("1");
		return System.Convert.ToInt32(inputStream.ReadLine().Trim(), 16);
	}

	// Returns wheather the given button with the given bit mask is pressed or not
	public bool getButton(int bitMask) {
		Int32 buttonMask = this.getButtons();
		return (buttonMask & bitMask) != 0;
	}

	// Returns the analog signal of the sliders and potis
	private string getAnalog(bool reload = true) {
		if (reload) {
			inputStream.Write("4");
			analogRawData = inputStream.ReadLine();
		}

		return analogRawData;
	}

	// Returns the vlaue for the poti1 (0 ... 2096)
	public long getPoti1(bool reload = true) {
		string analog = this.getAnalog(reload);
		string[] values = analog.Split(' ');
		return System.Convert.ToInt32(values[1].Trim(), 16);
	}

	// Returns the vlaue for the poti2 (0 ... 2096)
	public long getPoti2(bool reload = true) {
		string analog = this.getAnalog(reload);
		string[] values = analog.Split(' ');
		return System.Convert.ToInt32(values[2].Trim(), 16);
	}

	// Returns the vlaue for the slider1 (0 ... 2096)
	public long getSlider2(bool reload = true) {
		string analog = this.getAnalog(reload);
		string[] values = analog.Split(' ');
		return System.Convert.ToInt32(values[3].Trim(), 16);
	}

	// Returns the vlaue for the slider2 (0 ... 2096)
	public long getSlider1(bool reload = true) {
		string analog = this.getAnalog(reload);
		string[] values = analog.Split(' ');
		return System.Convert.ToInt32(values[4].Trim(), 16);
	}

	// Returns the accelerometer data
	private String getAccelerometerRawData(bool reload = true) {
		if (reload) {
			inputStream.Write("a");
			accelerometerRawData = inputStream.ReadLine().Trim();
		}

		return accelerometerRawData;
	}

	// returns the normalized accelerometer data for the x-axis (-1 ... 1)
	public float getAccelerometerXAxis(bool reload = true) {
		string rawData = this.getAccelerometerRawData(reload);
		string[] values = rawData.Split(' ');
		int val = System.Convert.ToInt32(values[1].Trim(), 16);
		if (val <= 127) {
			val = val;
		} else {
			val -= 256;
		}

		return (float) val / 128.0f;
	}

	// returns the normalized accelerometer data for the y-axis (-1 ... 1)
	public float getAccelerometerYAxis(bool reload = true) {
		string rawData = this.getAccelerometerRawData(reload);
		string[] values = rawData.Split(' ');
		int val = System.Convert.ToInt32(values[2].Trim(), 16);
		if (val <= 127) {
			val = val;
		} else {
			val -= 256;
		}
		
		return (float) val / 128.0f;
	}

	// returns the normalized accelerometer data for the z-axis (-1 ... 1)
	public float getAccelerometerZAxis(bool reload = true) {
		string rawData = this.getAccelerometerRawData(reload);
		string[] values = rawData.Split(' ');
		int val = System.Convert.ToInt32(values[3].Trim(), 16);
		if (val <= 127) {
			val = val;
		} else {
			val -= 256;
		}
		
		return (float) val / 128.0f;
	}

	// returns a vector which represents the current acceleroation
	public Vector3 getAccelerometerVector() {
		// Create new dierction vector
		// NOTE: We need to flip x and z axes to be compatible to Unity coordinate system
		return new Vector3(getAccelerometerYAxis(true), getAccelerometerZAxis(false), getAccelerometerXAxis(false));
	}

	// returns the raw data of the microphone on the controller
	private string getSoundRawData() {
		inputStream.Write("s");
		return inputStream.ReadLine().Trim();
	}

	// returns the sound data from 0 to 1 of the microphone
	public float getSound() {
		string rawData = this.getSoundRawData();
		string[] values = rawData.Split(' ');
		float value = float.Parse(values[1], System.Globalization.CultureInfo.InvariantCulture);

		return value / 32768;
	}


	// switch the first LED on or off
	public void setLED1(bool state) {
		if (LED1 == state) {
			return;
		} else {
			LED1 = state;
		}
		if (state) {
			inputStream.Write("l 0 1\r\n");
		} else {
			inputStream.Write("l 0 0\r\n");
		}
		inputStream.ReadLine();
	}

	// switch the second LED on or off
	public void setLED2(bool state) {
		if (LED2 == state) {
			return;
		} else {
			LED2 = state;
		}
		if (state) {
			inputStream.Write("l 1 1\r\n");
		} else {
			inputStream.Write("l 1 0\r\n");
		}
		inputStream.ReadLine();
	}

	// switch the third LED on or off
	public void setLED3(bool state) {
		if (LED3 == state) {
			return;
		} else {
			LED3 = state;
		}
		if (state) {
			inputStream.Write("l 2 1\r\n");
		} else {
			inputStream.Write("l 2 0\r\n");
		}
		inputStream.ReadLine();
	}

	// switch the fourth LED on or off
	public void setLED4(bool state) {
		if (LED4 == state) {
			return;
		} else {
			LED4 = state;
		}
		if (state) {
			inputStream.Write("l 3 1\r\n");
		} else {
			inputStream.Write("l 3 0\r\n");
		}
		inputStream.ReadLine();
	}

	// sets the rumble motor from 0 to 100%
	public void setRumbleMotor(int percentage) {
		if (percentage > 100 || percentage < 0) {
			return;
		}
		if (percentage == rumbleMotor) {
			return;
		} else {
			rumbleMotor = percentage;
		}
		int value = percentage * 10;
		String str = "m " + value + "\r\n";
		inputStream.Write(str);
		inputStream.ReadLine();
	}

	// clears all outputs from the controller
	public void clear() {
		this.setLED1(false);
		this.setLED2(false);
		this.setLED3(false);
		this.setLED4(false);
		this.setRumbleMotor(0);
	}
}