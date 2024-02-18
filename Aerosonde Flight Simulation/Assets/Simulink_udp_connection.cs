using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine.UI;

public class Simulink_udp_connection : MonoBehaviour
{
    private UdpClient udpServer;
    public GameObject tb2;
    //private Vector3 tempPos;
    private Thread t;
    //public float movementSpeed;
    //private long lastSend;
    private IPEndPoint remoteEP;
    private float[] transformPosition = new float[3];
    private float[] Vb = new float[3];
    private float[] transformRotation = new float[3];
    private float[] wb = new float[3];
    public Text location;
    public Text velocity;
    public Text angular_orientation;
    public Text angular_velocity;

    // Send data to port 1234
    // format: string with 3 numbers separated by ','
    // encoding: 'utf-8'

    void Start()
    {
        transformPosition[0] = 2100;      //MATLAB X position          //UNITY Z POSITON
        transformPosition[1] = 2300;     //MATLAB Y position          //UNITY X POSITION
        transformPosition[2] = 200;     //MATLAB Z position          //UNITY Y POSITON
        transformRotation[2] = 270;    //yaw 
        
        udpServer = new UdpClient(1234);
        t = new Thread(() => {
            while (true)
            {
                this.receiveData();
            }
        });
        t.Start();
        t.IsBackground = true;
        remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 41234);
    }



    void Update()
    {
        transform.position = new Vector3(transformPosition[1], transformPosition[2], transformPosition[0]);
        transform.rotation = Quaternion.Euler(-transformRotation[1], transformRotation[2], -transformRotation[0]);
        location.text = "X: " + transformPosition[0].ToString("F1") + "  Y: " + transformPosition[1].ToString("F1") + "  Z: " + transformPosition[2].ToString("F1");
        velocity.text = "u: " + Vb[0].ToString("F1") + "  v: " + Vb[1].ToString("F1") + "  w: " + Vb[2].ToString("F1");
        angular_orientation.text = "phi: " + transformRotation[0].ToString("F1") + "  theta: " + transformRotation[1].ToString("F1") + "  psi: " + transformRotation[2].ToString("F1");
        angular_velocity.text = "p: " + wb[0].ToString("F1") + "  q: " + wb[1].ToString("F1") + "  r: " + wb[2].ToString("F1");
    }

    private void OnApplicationQuit()
    {
        udpServer.Close();
        t.Abort();
    }

    private void receiveData()
    {

        byte[] data = udpServer.Receive(ref remoteEP);
        if (data.Length > 0)
        {
            var str = System.Text.Encoding.Default.GetString(data);
            Debug.Log("Received Data: " + str);
            string[] messageParts = str.Split(',');

            // Position
            transformPosition[0] = float.Parse(messageParts[0], CultureInfo.InvariantCulture);
            transformPosition[1] = float.Parse(messageParts[1], CultureInfo.InvariantCulture);
            transformPosition[2] = float.Parse(messageParts[2], CultureInfo.InvariantCulture);

            // Linear Velocities (Vb) 
            Vb[0] = float.Parse(messageParts[3], CultureInfo.InvariantCulture);
            Vb[1] = float.Parse(messageParts[4], CultureInfo.InvariantCulture);
            Vb[2] = float.Parse(messageParts[5], CultureInfo.InvariantCulture);

            // Orientation
            transformRotation[0] = float.Parse(messageParts[6], CultureInfo.InvariantCulture);
            transformRotation[1] = float.Parse(messageParts[7], CultureInfo.InvariantCulture);
            transformRotation[2] = float.Parse(messageParts[8], CultureInfo.InvariantCulture);

            // Angular Velocities(wb)
            wb[0] = float.Parse(messageParts[9], CultureInfo.InvariantCulture);
            wb[1] = float.Parse(messageParts[10], CultureInfo.InvariantCulture);
            wb[2] = float.Parse(messageParts[11], CultureInfo.InvariantCulture);
        }
    }
}