using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ASLoader.math;

namespace ASLoader
{
    /// <summary>
    /// The ASMesh is responsible for loading the .txt file into
    /// vertice and indice arrays, after this.  The mesh is maintained
    /// by this class so all transform operations will be handled in this 
    /// class
    /// </summary>
    class ASMesh
    {
        /// <summary>
        /// ASVECTOR3[] - Array of vertices for this mesh
        /// ASFace[]    - Array containing the face definitions for this mesh
        /// ASVECTOR3[] - Array containing the vertex normals for this mesh, used for lighting
        /// int[]       - Array of indices for this mesh
        /// string      - The last error encountered by the loader
        /// bool        - Flag to determine validity of the model
        /// int         - Number of triangles in the mesh
        /// int         - Number of indices in model to update GUI
        /// int         - Number of vertices in model to update GUI
        /// </summary>
        private ASVECTOR4[] m_vertices;
        private ASFace[]    m_mesh;
        private int[]       m_indices;
        private string      m_lastErr = "";
        private bool        m_isModelValid;
        private int         m_numFaces;
        private int         m_numIndices;
        private int         m_numVertices;

        /// <summary>
        /// Constructs a new ASMesh instance, for a given filename.  The program
        /// will then attempt to load the provided txt file into the buffers, if
        /// everything is ok then the validModel flag is set to true, allowing us
        /// to draw the model to the graphics component
        /// </summary>
        /// <param name="modelName">Name of the model file</param>
        public ASMesh(string modelName)
        {
            // If the buffer initialisation succeeded we know we have a valid mesh.
            // this flag will allow us to perform matrix math
            m_isModelValid = InitBuffers(modelName);
        }

        /// <summary>
        /// Attempt to initialise the buffers for this object, if everything was ok
        /// then we can perform other matrix operations, else the model was invalid
        /// and we can raise an error to the user.
        /// </summary>
        /// <param name="modelName">The filename for the given model</param>
        /// <returns>True if the buffers were initialised successfully, else false</returns>
        private bool InitBuffers(string modelName)
        {
            var reader = new StreamReader(modelName);

            if (reader == null) throw new NullReferenceException("reader");

            // If the model name wasn't valid then the application will crash

            // Get information about the mesh - we know the first line in the provided
            // file formats is the total number of vertices in the file.
            m_numVertices = Convert.ToInt32(reader.ReadLine());
            m_numIndices  = m_numVertices;

            // Initialise the size of the buffers
            m_vertices = new ASVECTOR4[m_numVertices];
            m_indices  = new int[m_numIndices];

            // Populate the vertex buffers - if fail then break, the error is logged in the exception
            if (!FillVertexBuffer(reader))
                return false;

            // Read the number of faces and initialise the face buffer
            m_numFaces = Convert.ToInt32(reader.ReadLine());
            m_mesh     = new ASFace[m_numFaces];

            // Populate the geometry buffer - if fail then break, the error is logged in the exception
            if (!FillGeometryBuffer(reader))
                return false;

            // Check that no error has been set, if it has (which is shouldn't) then something has gone
            // wrong, in which case we break out
            if (m_lastErr == "" || string.IsNullOrEmpty(m_lastErr))
                return true;

            // Something went wrong - the model is not valid
            return false;
        }

        /// <summary>
        /// Recieves the pointer to the current location of the StreamReader, from here we
        /// read all vertice and indice information into the respective buffers
        /// </summary>
        /// <param name="reader">Pointer to the current stream reader</param>
        /// <returns>True if the array was populated, else false, also sets last error in exception</returns>
        internal bool FillVertexBuffer(StreamReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");

            try
            {
                // Loop numVertices times to build the vertex buffers
                for (var i = 0; i < m_numVertices; i++)
                {
                    // Values to hold the x,y,z position of this vertex
                    var nums = reader.ReadLine();
                    if(nums == null) continue;;
                    var bits = nums.Trim().Split(' ');

                    // Read the next three doubles from the file into x,y,z
                    var x = float.Parse(bits[0]);
                    var y = float.Parse(bits[1]);
                    var z = float.Parse(bits[2]);

                    m_vertices[i] = new ASVECTOR4(x, y, z);

                    // Set the indice for this vertex
                    m_indices[i] = i;
                }

                return true;

            }
            // Something went wrong, probably an index out of bounds exception or something.
            catch (Exception e)
            {
                m_lastErr = e.ToString();
                return false;
            }
        }

        /// <summary>
        /// Recieves the pointer to the current location of the StreamReader, from here we
        /// read all face information into the geometry buffer
        /// </summary>
        /// <param name="reader">Pointer to the current stream reader</param>
        /// <returns>True if the array was populated, else false, also sets last error in exception</returns>
        internal bool FillGeometryBuffer(StreamReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");

            try
            {
                // Loop numVertices times to build the vertex buffers
                for (var i = 0; i < m_numFaces; i++)
                {
                    // Values to hold the x,y,z position of this vertex
                    var nums = reader.ReadLine();
                    if (nums == null) continue;
                    var bits = nums.Trim().Split(' ');

                    // Don't read from location 0 of bits as this contains the redundant 0 figure.
                    // We could attempt to trim "3" by removing it from array but this is simple for now.
                    // Get the int value of each point
                    var pA = int.Parse(bits[1]);
                    var pB = int.Parse(bits[2]);
                    var pC = int.Parse(bits[3]);

                    // Read the next three doubles from the file into x,y,z, we then create a new
                    // vector made from each point
                    var pointA = new ASVECTOR4(m_vertices[pA].Points[0], m_vertices[pA].Points[1], m_vertices[pA].Points[2]);
                    var pointB = new ASVECTOR4(m_vertices[pB].Points[0], m_vertices[pB].Points[1], m_vertices[pB].Points[2]);
                    var pointC = new ASVECTOR4(m_vertices[pC].Points[0], m_vertices[pC].Points[1], m_vertices[pC].Points[2]);

                    // Create the face - we use an ASMATRIX3 so we can map all points to one object
                    m_mesh[i] = new ASFace(pointA, pointB, pointC);
                }

                return true;

            }
            // Something went wrong, probably an index out of bounds exception or something.
            catch (Exception e)
            {
                m_lastErr = e.ToString();
                return false;
            }
        }

        /// <summary>
        /// Builds a Dictionary holding all information about the model, this will allow
        /// us to access its context from other areas in the application.
        /// </summary>
        /// <returns>Dictionary containing all info</returns>
        public Dictionary<string, object> GetMeshData()
        {
            // Base dictionary to be appeneded to, we use String and Object because
            // there are many components of different type that could exist
            var meshData = new Dictionary<string, object>();

            // Check if the model is valid, if not return a nice response message, we don't put
            // the other info in this response just incase things are null, could break? I don't know...
            if (!m_isModelValid)
            {
                meshData.Add("response", "Sorry, there was an error loading the model: " + m_lastErr);
                return meshData;
            }

            // We have successfully loaded the mesh, return all info
            meshData.Add("response", "The model was generated successfully, it has " + m_numFaces + " faces, and " + m_numVertices + " vertices.");
            meshData.Add("vertices", m_vertices);
            meshData.Add("indices", m_indices);
            meshData.Add("faces", m_mesh);
            meshData.Add("numVertices", m_numVertices);
            meshData.Add("numIndices", m_numIndices);
            meshData.Add("numFaces", m_numFaces);

            // Return the object
            return meshData;
        }

    }
}
