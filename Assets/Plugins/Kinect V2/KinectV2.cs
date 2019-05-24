
//MultisourceReader (Color + Depth)  Anfang

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class KinectV2 : DepthSensorBase
{   
    
    private Windows.Kinect.KinectSensor sensor;
    private MultiSourceFrameReader reader;
    private Texture2D colorTexture;
    private byte[] colorData;
    private ushort[] depthData;
    private int depthWidth;
    private int depthHeigth;

    public int ColorWidth { get; private set; }
    public int ColorHeight { get; private set; }

    public override int Width => depthWidth;

    public override int Height => depthHeigth;

    public override ushort[] depthImage
    {
        get { return depthData; }
    }

    public Texture2D GetColorTexture()
    {
        return colorTexture;
    }


    public override bool pollDepth()
    {
        if (reader != null)
        {
            var frame = reader.AcquireLatestFrame();
            if (frame != null)
            {
          
                var colorFrame = frame.ColorFrameReference.AcquireFrame();
                if (colorFrame != null)
                {
                    var depthFrame = frame.DepthFrameReference.AcquireFrame();
                    if (depthFrame != null)
                    {
                        colorFrame.CopyConvertedFrameDataToArray(colorData, ColorImageFormat.Rgba);
                        colorTexture.LoadRawTextureData(colorData);
                        colorTexture.Apply();

                        depthFrame.CopyFrameDataToArray(depthData);

                        depthFrame.Dispose();
                        depthFrame = null;
                    }

                    colorFrame.Dispose();
                    colorFrame = null;
                }

                frame = null;

                return true;
            }
        }

        return false;
    }
    

    private void Start()
    {
        sensor = Windows.Kinect.KinectSensor.GetDefault();

        if (sensor != null)
        {
            reader = sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth);
            //reader = sensor.DepthFrameSource.OpenReader();

            var colorFrameDesc = sensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Rgba);
            ColorWidth = colorFrameDesc.Width;
            ColorHeight = colorFrameDesc.Height;

            colorTexture = new Texture2D(colorFrameDesc.Width, colorFrameDesc.Height, TextureFormat.RGBA32, false);
            colorData = new byte[colorFrameDesc.BytesPerPixel * colorFrameDesc.LengthInPixels];

            depthData = new ushort[sensor.DepthFrameSource.FrameDescription.LengthInPixels];
            depthWidth = sensor.DepthFrameSource.FrameDescription.Width;
            depthHeigth = sensor.DepthFrameSource.FrameDescription.Height;

            if (!sensor.IsOpen)
                sensor.Open();
        }
        else
        {
            Debug.LogErrorFormat("Failed to acquire Kinect Sensor!");
        }
    }

    private void OnDestroy()
    {
        if (reader != null)
        {
            reader.Dispose();
            reader = null;
        }

        if (sensor != null)
        {
            if (sensor.IsOpen)
                sensor.Close();

            sensor = null;
        }
    }
  
}
//MultisourceReader (Color + Depth)  Ende*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class KinectV2 : DepthSensorBase
{

    private Windows.Kinect.KinectSensor sensor;
    private DepthFrameReader reader;
    private ushort[] data;
    private int width;
    private int heigth;

    public override int Width => width;

    public override int Height => heigth;

    public override ushort[] depthImage
    {
        get { return data; }
    }

    public override bool pollDepth()
    {
        if (reader != null)
        {
            var frame = reader.AcquireLatestFrame();
            if (frame != null)
            {
                frame.CopyFrameDataToArray(data);
                frame.Dispose();
                frame = null;

                return true;
            }
        }

        return false;
    }

    private void Start()
    {
        sensor = Windows.Kinect.KinectSensor.GetDefault();

        if (sensor != null)
        {
            reader = sensor.DepthFrameSource.OpenReader();
            data = new ushort[sensor.DepthFrameSource.FrameDescription.LengthInPixels];
            width = sensor.DepthFrameSource.FrameDescription.Width;
            heigth = sensor.DepthFrameSource.FrameDescription.Height;

            if (!sensor.IsOpen)
                sensor.Open();
        }
        else
        {
            Debug.LogErrorFormat("Failed to acquire Kinect Sensor!");
        }
    }

    private void OnDestroy()
    {
        if (reader != null)
        {
            reader.Dispose();
            reader = null;
        }

        if (sensor != null)
        {
            if (sensor.IsOpen)
                sensor.Close();

            sensor = null;
        }
    }

} */