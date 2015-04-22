using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// This file contains 
//
namespace ASLoader.math
{
    /// <summary>
    /// 4x4 matrix to perform translations etc..
    /// </summary>
    public class ASMATRIX4
    {
        // 
        public ASVECTOR4[] Matrix = new ASVECTOR4[4];


        /// <summary>
        /// Multiply two matrices together to get the cross product
        /// </summary>
        /// <param name="mA"></param>
        /// <param name="mB"></param>
        /// <returns></returns>
        public static ASMATRIX4 operator *(ASMATRIX4 mA, ASMATRIX4 mB)
        {
            //  Creates a new zeroed output matrix
            var m = new ASMATRIX4();
            
            // Multiply the two matrixes together and return the output matrix
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    m.Matrix[i].Points[j] =
                        (mB.Matrix[i].Points[0]*mA.Matrix[0].Points[j]) +
                        (mB.Matrix[i].Points[1]*mA.Matrix[1].Points[j]) +
                        (mB.Matrix[i].Points[2]*mA.Matrix[2].Points[j]) +
                        (mB.Matrix[i].Points[3]*mA.Matrix[3].Points[j]);
                }
            }
            return m;
        }

        /// <summary>
        /// Default constructor for an ASMATRIX, will create it as
        /// an identity matrix.
        /// </summary>
        public ASMATRIX4()
        {
            CreateIdentityMatrix();
        }

        /// <summary>
        /// Create a matrix given 4 vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        public ASMATRIX4(ASVECTOR4 v1, ASVECTOR4 v2, ASVECTOR4 v3, ASVECTOR4 v4)
        {
            Matrix[0] = v1;
            Matrix[1] = v2;
            Matrix[2] = v3;
            Matrix[3] = v4;
        }

        /// <summary>
        /// Builds an identity matrix and returns it to the caller
        /// </summary>
        /// <returns></returns>
        public void CreateIdentityMatrix()
        {
            Matrix[0] = new ASVECTOR4(1, 0, 0, 0);
            Matrix[1] = new ASVECTOR4(0, 1, 0, 0);
            Matrix[2] = new ASVECTOR4(0, 0, 1, 0);
            Matrix[3] = new ASVECTOR4(0, 0, 0, 1);
        }

        /// <summary>
        /// Zeroes out the matrices
        /// </summary>
        public void ZeroMatrix()
        {
            for (int i = 0; i < 4; i++)
                Matrix[i].ZeroVector();
        }

        /// <summary>
        /// Creates a new 4x4 perspective matrix
        /// </summary>
        /// <param name="focalLength"></param>
        /// <returns></returns>
        public static ASMATRIX4 CreatePerspectiveMatrix(double focalLength)
        {
            // Reset the matrix to an identity matrix
            var m = new ASMATRIX4();

            // Create the perspective matrix
            m.Matrix[3].Points[2] = 1 / focalLength;
            m.Matrix[3].Points[3] = 0;
            
            return m;
        }

        /// <summary>
        /// Builds a transaltion matrix and returns it to the caller
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static ASMATRIX4 CreateTranslationMatrix(double x, double y, double z)
        {
            // reset to identity matrix
            var m = new ASMATRIX4();

            // Set the translation matrix
            m.Matrix[0].Points[3] = x;
            m.Matrix[1].Points[3] = y;
            m.Matrix[2].Points[3] = z;

            return m;
        }

        /// <summary>
        /// Builds a transaltion matrix and returns it to the caller
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static ASMATRIX4 CreateScalingMatrix(double x, double y, double z)
        {
            // Zero the matrix
            var m = new ASMATRIX4();

            // Scale the matrix
            m.Matrix[0].Points[0] = x;
            m.Matrix[1].Points[1] = y;
            m.Matrix[2].Points[2] = z;

            return m;
        }

        /// <summary>
        /// Creates a rotation matrix around the X origin, given the angle
        /// in degree
        /// </summary>
        /// <param name="radians"></param>
        private static ASMATRIX4 CreateRotationAroundX(double radians)
        {
            // See if the angle is valid, if not set default
            CheckAngle(radians, out radians);

            // Zero the Matrix
            var m = new ASMATRIX4();

            // Create the X Rotation Matrix
            m.Matrix[1].Points[1] = Math.Cos(radians);
            m.Matrix[1].Points[2] = Math.Sin(radians);
            m.Matrix[2].Points[1] = -(Math.Sin(radians));
            m.Matrix[2].Points[2] = Math.Cos(radians);

            return m;
        }

        /// <summary>
        /// Creates a rotation matrix around the Y origin, given the angle
        /// in degree
        /// </summary>
        /// <param name="radians"></param>
        private static ASMATRIX4 CreateRotationAroundY(double radians)
        {
            // See if the angle is valid, if not set default
            CheckAngle(radians, out radians);

            // Zero the Matrix
            var m = new ASMATRIX4();

            // Create the Y Rotation Matrix
            m.Matrix[0].Points[0] = Math.Cos(radians);
            m.Matrix[0].Points[2] = -(Math.Sin(radians));
            m.Matrix[2].Points[0] = Math.Sin(radians);
            m.Matrix[2].Points[2] = Math.Cos(radians);

            return m;
        }

        /// <summary>
        /// Creates a rotation matrix around the Z origin, given the angle
        /// in degree
        /// </summary>
        /// <param name="radians"></param>
        private static ASMATRIX4 CreateRotationAroundZ(double radians)
        {
            // See if the angle is valid, if not set default
            CheckAngle(radians, out radians);

            // Zero the Matrix
            var m = new ASMATRIX4();

            // Create the X Rotation Matrix
            m.Matrix[0].Points[0] = Math.Cos(radians);
            m.Matrix[0].Points[1] = Math.Sin(radians);
            m.Matrix[1].Points[0] = -(Math.Sin(radians));
            m.Matrix[1].Points[1] = Math.Cos(radians);

            return m;
        }

        /// <summary>
        /// Converts degrees to radians so we can ensure we rotate by the correct amount, this is because
        /// the sliders on the GUI are in Degrees (0-360) and not radians
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static double ConvertDegressToRadians(double degrees)
        {
            return (Math.PI/180)*degrees;
        }

        /// <summary>
        /// Creates a rotation matrix using the rotation methods - this is a private interface
        /// as we access it via the RotateByDegrees method
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        private static ASMATRIX4 CreateRotation(double x, double y, double z)
        {
            var m = CreateRotationAroundX(x);
            m = m*CreateRotationAroundY(y);
            m = m*CreateRotationAroundZ(z);

            return m;
        }

        /// <summary>
        /// Public interface to create a new rotation matrix, this has default parameters of 
        /// 0 in the event that no parameters are passed (shoudln't happen)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static ASMATRIX4 RotateByDegrees(double x = 0, double y = 0, double z = 0)
        {
            return CreateRotation(ConvertDegressToRadians(x), ConvertDegressToRadians(y), ConvertDegressToRadians(z));
        }

        /// <summary>
        /// Simple method to check if we have a valid angle, given an 
        /// input and output parameter, we see if the angle is within the range 0 - 360
        /// if not we return default values, else return the angle
        /// </summary>
        /// <param name="input"></param>
        /// <param name="angle"></param>
        public static void CheckAngle(double input, out double angle)
        {
            if (input > 360)
                angle = 0;
            if (input < 0)
                angle = 360;
            angle = input;
        }

        /// <summary>
        /// Convert the matrix to a float array
        /// </summary>
        /// <returns></returns>
        public double[] MatrixToFloat()
        {
            var outputFloat = new double[16];
            outputFloat[0]  = Matrix[0].Points[0];
            outputFloat[1]  = Matrix[0].Points[1];
            outputFloat[2]  = Matrix[0].Points[2];
            outputFloat[3]  = Matrix[0].Points[3];
            outputFloat[4]  = Matrix[1].Points[0];
            outputFloat[5]  = Matrix[1].Points[1];
            outputFloat[6]  = Matrix[1].Points[2];
            outputFloat[7]  = Matrix[1].Points[3];
            outputFloat[8]  = Matrix[2].Points[0];
            outputFloat[9]  = Matrix[2].Points[1];
            outputFloat[10] = Matrix[2].Points[2];
            outputFloat[11] = Matrix[2].Points[3];
            outputFloat[12] = Matrix[3].Points[0];
            outputFloat[13] = Matrix[3].Points[1];
            outputFloat[14] = Matrix[3].Points[2];
            outputFloat[15] = Matrix[3].Points[3];

            return outputFloat;
        }
    }
}
