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
        private ASVECTOR4[] m_points = new ASVECTOR4[3];

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
