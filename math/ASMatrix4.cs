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
        /// Default constructor for an ASMATRIX, will create it as
        /// an identity matrix.
        /// </summary>
        public ASMATRIX4()
        {
            CreateIdentityMatrix();
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
        /// Creates a new 4x4 perspective matrix
        /// </summary>
        /// <param name="focalLength"></param>
        /// <returns></returns>
        public void CreatePerspectiveMatrix(double focalLength)
        {
            // Reset the matrix to an identity matrix
            CreateIdentityMatrix();

            // Create the perspective matrix
            Matrix[3].Points[2] = 1 / focalLength;
            Matrix[3].Points[3] = 1;
        }

        /// <summary>
        /// Builds a transaltion matrix and returns it to the caller
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public void CreateTranslationMatrix(double x, double y, double z)
        {
            // reset to identity matrix
            CreateIdentityMatrix();

            // Set the translation matrix
            Matrix[0].Points[3] = x;
            Matrix[1].Points[3] = y;
            Matrix[2].Points[3] = z;
        }

        /// <summary>
        /// Builds a transaltion matrix and returns it to the caller
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public void CreateScalingMatrix(double x, double y, double z)
        {
            // Reset to identity matrix
            CreateIdentityMatrix();

            Matrix[0].Points[0] = x;
            Matrix[1].Points[1] = y;
            Matrix[2].Points[2] = z;
            Matrix[3].Points[3] = 1;
        }

        public void CreateRotationMatrix(double x, double y, double z)
        {
        
        }

        /// <summary>
        /// Multiply two matrixes together.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public ASMATRIX4 MultiplyMatrix(ASMATRIX4 m)
        { 
            ASMATRIX4 newMatrix = new ASMATRIX4();
            newMatrix.Matrix[0] = new ASVECTOR4(
                    Matrix[0].Points[0] * m.Matrix[0].Points[0] + Matrix[0].Points[1] * m.Matrix[0].Points[0] + Matrix[0].Points[2] * m.Matrix[0].Points[0] + Matrix[0].Points[3] * m.Matrix[0].Points[0],
                    Matrix[0].Points[0] * m.Matrix[0].Points[1] + Matrix[0].Points[1] * m.Matrix[0].Points[1] + Matrix[0].Points[2] * m.Matrix[0].Points[1] + Matrix[0].Points[3] * m.Matrix[0].Points[1],
                    Matrix[0].Points[0] * m.Matrix[0].Points[2] + Matrix[0].Points[1] * m.Matrix[0].Points[2] + Matrix[0].Points[2] * m.Matrix[0].Points[2] + Matrix[0].Points[3] * m.Matrix[0].Points[2],
                    Matrix[0].Points[0] * m.Matrix[0].Points[3] + Matrix[0].Points[1] * m.Matrix[0].Points[3] + Matrix[0].Points[2] * m.Matrix[0].Points[3] + Matrix[0].Points[3] * m.Matrix[0].Points[3]
            );
            newMatrix.Matrix[1] = new ASVECTOR4(
                    Matrix[1].Points[0] * m.Matrix[0].Points[0] + Matrix[1].Points[1] * m.Matrix[0].Points[0] + Matrix[1].Points[2] * m.Matrix[0].Points[0] + Matrix[1].Points[3] * m.Matrix[0].Points[0],
                    Matrix[1].Points[0] * m.Matrix[0].Points[1] + Matrix[1].Points[1] * m.Matrix[0].Points[1] + Matrix[1].Points[2] * m.Matrix[0].Points[1] + Matrix[1].Points[3] * m.Matrix[0].Points[1],
                    Matrix[1].Points[0] * m.Matrix[0].Points[2] + Matrix[1].Points[1] * m.Matrix[0].Points[2] + Matrix[1].Points[2] * m.Matrix[0].Points[2] + Matrix[1].Points[3] * m.Matrix[0].Points[2],
                    Matrix[1].Points[0] * m.Matrix[0].Points[3] + Matrix[1].Points[1] * m.Matrix[0].Points[3] + Matrix[1].Points[2] * m.Matrix[0].Points[3] + Matrix[1].Points[3] * m.Matrix[0].Points[3]
            );
            newMatrix.Matrix[2] = new ASVECTOR4(
                    Matrix[2].Points[0] * m.Matrix[0].Points[0] + Matrix[2].Points[1] * m.Matrix[0].Points[0] + Matrix[2].Points[2] * m.Matrix[0].Points[0] + Matrix[2].Points[3] * m.Matrix[0].Points[0],
                    Matrix[2].Points[0] * m.Matrix[0].Points[1] + Matrix[2].Points[1] * m.Matrix[0].Points[1] + Matrix[2].Points[2] * m.Matrix[0].Points[1] + Matrix[2].Points[3] * m.Matrix[0].Points[1],
                    Matrix[2].Points[0] * m.Matrix[0].Points[2] + Matrix[2].Points[1] * m.Matrix[0].Points[2] + Matrix[2].Points[2] * m.Matrix[0].Points[2] + Matrix[2].Points[3] * m.Matrix[0].Points[2],
                    Matrix[2].Points[0] * m.Matrix[0].Points[3] + Matrix[2].Points[1] * m.Matrix[0].Points[3] + Matrix[2].Points[2] * m.Matrix[0].Points[3] + Matrix[2].Points[3] * m.Matrix[0].Points[3]
            );
            newMatrix.Matrix[3] = new ASVECTOR4(
                    Matrix[3].Points[0] * m.Matrix[0].Points[0] + Matrix[3].Points[1] * m.Matrix[0].Points[0] + Matrix[3].Points[2] * m.Matrix[0].Points[0] + Matrix[3].Points[3] * m.Matrix[0].Points[0],
                    Matrix[3].Points[0] * m.Matrix[0].Points[1] + Matrix[3].Points[1] * m.Matrix[0].Points[1] + Matrix[3].Points[2] * m.Matrix[0].Points[1] + Matrix[3].Points[3] * m.Matrix[0].Points[1],
                    Matrix[3].Points[0] * m.Matrix[0].Points[2] + Matrix[3].Points[1] * m.Matrix[0].Points[2] + Matrix[3].Points[2] * m.Matrix[0].Points[2] + Matrix[3].Points[3] * m.Matrix[0].Points[2],
                    Matrix[3].Points[0] * m.Matrix[0].Points[3] + Matrix[3].Points[1] * m.Matrix[0].Points[3] + Matrix[3].Points[2] * m.Matrix[0].Points[3] + Matrix[3].Points[3] * m.Matrix[0].Points[3]
            );
            return newMatrix;
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
