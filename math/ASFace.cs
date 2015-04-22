using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASLoader.math
{
    /// <summary>
    /// Represent a face (3 vertexes) and will later be used to draw a triangle
    /// to create the mesh.
    /// </summary>
    class ASFace
    {
        /// <summary>
        /// Private members
        /// </summary>
        private ASVECTOR4[] m_points = new ASVECTOR4[3];
        private ASVECTOR4   m_center = new ASVECTOR4();

        /// <summary>
        /// Creates a new ASFace array object to hold each point
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="pointC"></param>
        public ASFace(ASVECTOR4 pointA, ASVECTOR4 pointB, ASVECTOR4 pointC)
        {
            m_points[0] = pointA;
            m_points[1] = pointB;
            m_points[2] = pointC;
        }

        /// <summary>
        /// Empty constructor to initialise the points structure to be all 0
        /// </summary>
        public ASFace()
        {
            for (var i = 0; i < 3; i++)
                m_points[i] = new ASVECTOR4();
        }

        /// <summary>
        /// Computes the normals for this face, these will be stored as
        /// U, X, V in the vector, the W parameter will be 1 as we don't
        /// have a ASVECTOR3 object (no need for it when we can just use VEC4)
        /// </summary>
        /// <returns></returns>
        public ASVECTOR4 ComputeFaceNormals()
        {
            // Get the UV edges of our triangle, we can then calculate the face
            // normals from these values.
            var vecA = new ASVECTOR4();
            vecA.Points[0] = m_points[0].Points[0] - m_points[1].Points[0];
            vecA.Points[1] = m_points[0].Points[1] - m_points[1].Points[1];
            vecA.Points[2] = m_points[0].Points[2] - m_points[1].Points[2];

            var vecB = new ASVECTOR4();
            vecB.Points[0] = m_points[1].Points[0] - m_points[2].Points[0];
            vecB.Points[1] = m_points[1].Points[1] - m_points[2].Points[1];
            vecB.Points[2] = m_points[1].Points[2] - m_points[2].Points[2];

            // Get the cross product of the two vectors
            var norm = (vecA*vecB).Normalise();

            // Normalise the vector to get the unit lenght
            return norm;
        }

        /// <summary>
        /// Computes the center of this face and then returns the vector describing
        /// the center of this face. This allows us to apply shading across the face
        /// based on normal values
        /// </summary>
        public ASVECTOR4 GetCenter()
        {
            // Zero the vector 
            m_center.ZeroVector();

            // Add all components to the vector
            m_center.AddToVector(m_points[0]);
            m_center.AddToVector(m_points[1]);
            m_center.AddToVector(m_points[2]);

            // Divide the vector by the amount of components and return to give the
            // center point
            return m_center.MultiplyVector(1d/3); 
        }

        /// <summary>
        /// Returns the ASPoint at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The point at the index, if too high return point at 0</returns>
        public ASVECTOR4 GetPointAtIndex(int index)
        {
            return m_points[index];
        }

        /// <summary>
        /// Transforms the face by a transformation matrix, this will allow
        /// the mesh to be scaled
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public ASFace TransformFace(ASMATRIX4 matrix)
        {
            var transformedFace = new ASFace();

            for (var i = 0; i < 3; i++)
            {
                transformedFace.m_points[i] = m_points[i].TransformVector(matrix);
                transformedFace.m_points[i] = transformedFace.m_points[i].Rescale();
            }

            return transformedFace;
        }
    }
}
