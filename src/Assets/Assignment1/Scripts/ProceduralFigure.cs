using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum FigureType { Tetrahedron, UTetrahedron, Cube, UCube, Heart, LetterA, WrongCube, UUCube, Octahedron}
[RequireComponent(typeof(MeshFilter))]
[RequireComponent (typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class ProceduralFigure : MonoBehaviour
{
    [SerializeField] private FigureType _figureType;

    private Mesh _mesh;
    private Vector3[] _vertices;
    private int[] _triangles;
    private MeshCollider _meshCollider;
    [SerializeField] private float _heartWidth = 4;

    private float _a = 3;
    private float _b = 4.5f;
    private float _c = 5.5f;
    private float _d = 7;
    private float _e = 4.5f;
    private float _f = 2;
    private float _g = 1;

    private void Awake()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _meshCollider = GetComponent<MeshCollider>();
        FigureCreation();
        UpdateMesh();
    }

    private void FigureCreation()
    {
        switch (_figureType)
        {
            case FigureType.Tetrahedron:
                CreateTetrahaedron();
                break;
            case FigureType.Cube:
                CreateCube();
                break;
            case FigureType.UCube:
                CreateUniqueCube();
                break;
            case FigureType.UUCube:
                CreateUnfilledUniqueCube();
                break;
            case FigureType.UTetrahedron:
                CreateUniqueTetrahaedron();
                break;
            case FigureType.WrongCube:
                CreateCoolWrongCube();
                break;
            case FigureType.Heart:
                CreateHeart();
                break;
            case FigureType.LetterA:
                CreateA();
                break;
            case FigureType.Octahedron:
                CreateOctahedron();
                break;
            default:
                break;
        }
    }

    private void CreateOctahedron()
    {
        _vertices = new Vector3[] { new Vector3(0, 1, 0), new Vector3(-0.5f, 0, -0.5f), new Vector3(0.5f, 0, -0.5f), new Vector3(-0.5f, 0, 0.5f), new Vector3(0.5f, 0, 0.5f), new Vector3(0, -1, 0)};
        _triangles = new int[] { 0, 2, 1, 0, 3, 4, 0, 4, 2, 0, 1, 3, 5, 1, 2, 5, 2, 4, 5, 4, 3, 5, 3, 1};
    }

    private void CreateA()
    {
        _vertices = new Vector3[] {
            new Vector3(0, _a, 0), new Vector3(_g, _a, 0), new Vector3(_f, 0, 0), new Vector3(_e, 0, 0), new Vector3(_f, _d, 0), new Vector3(0, _d, 0), new Vector3(0, _c, 0), new Vector3(_g - 0.5f, _c, 0), new Vector3(_g - 0.2f, _b, 0), new Vector3(0, _b, 0), // Front right 0 - 9
            new Vector3(0, _a, _heartWidth), new Vector3(_g, _a, _heartWidth), new Vector3(_f, 0, _heartWidth), new Vector3(_e, 0, _heartWidth), new Vector3(_f, _d, _heartWidth), new Vector3(0, _d, _heartWidth), new Vector3(0, _c, _heartWidth), new Vector3(_g - 0.5f, _c, _heartWidth), new Vector3(_g - 0.2f, _b, _heartWidth), new Vector3(0, _b, _heartWidth)
        };
        _triangles = new int[] {
            0, 9, 8,
            0, 8, 1,
            1, 8, 2,
            2, 8, 4,
            2, 4, 3,
            8, 7, 4,
            7, 6, 4,
            6, 5, 4,
            10, 18, 19,
            10, 11, 18,
            11, 12, 18,
            12, 14, 18,
            12, 13, 14,
            18, 14, 17,
            17, 14, 15,
            17, 15, 16,
            // Sides
            5, 15, 14,
            5, 14, 4,
            4, 14, 13,
            4, 13, 3,
            // Bottom
            3, 13, 12,
            3, 12, 2,
            // Inside
            12, 11, 1,
            12, 1, 2,
            // Middle bottom
            1, 11, 10,
            1, 10, 0,
            // triangle
            9, 19, 8,
            8, 19, 18,
            8, 18, 17,
            8, 17, 7,
            7, 17, 16,
            7, 16, 6,
            // Other side
            0, 10, 19,
            0, 19, 9
        };
    }

    private void CreateUnfilledUniqueCube()
    {
        _vertices = new Vector3[] {
            new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 1, -1), // Left
            new Vector3(0, 1, -1), new Vector3(0, 0, -1), new Vector3(0, 0, 0),

            new Vector3(0, 1, 0), new Vector3(1, 1, 0), new Vector3(0, 1, -1), // Top
            new Vector3(1, 1, 0), new Vector3(1, 1, -1), new Vector3(0, 1, -1),

            new Vector3(1, 1, -1), new Vector3(1, 1, 0), new Vector3(1, 0, 0), // Right
            new Vector3(1, 1, -1), new Vector3(1, 0, 0), new Vector3(1, 0, -1),

            new Vector3(1, 0, -1), new Vector3(1, 0, 0), new Vector3(0, 0, 0), // Bottom
            new Vector3(1, 0, -1), new Vector3(0, 0, 0), new Vector3(0, 0, -1),
        };
        _triangles = new int[] {
            0, 1, 2, // left
            3, 4, 5,
            6, 7, 8, // top
            9, 10, 11,
            12, 13, 14, // right
            15, 16, 17,
            18, 19, 20, // bottom
            21, 22, 23
        };
    }

    private void CreateHeart()
    {
        _vertices = new Vector3[] {
            new Vector3(0, 0, 0), new Vector3(0, 6.4f, 0), new Vector3(1, 8, 0), new Vector3(3, 9, 0),new Vector3(5, 8, 0), new Vector3(5.4f,6.4f, 0), new Vector3(5.2f, 5, 0), // 0-6 front right
            new Vector3(-1, 8, 0), new Vector3(-3, 9, 0),new Vector3(-5, 8, 0), new Vector3(-5.4f,6.4f, 0), new Vector3(-5.2f, 5, 0), // 7 - 11 front left
            new Vector3(0, 0, _heartWidth), new Vector3(0, 6.4f, _heartWidth), new Vector3(1, 8, _heartWidth), new Vector3(3, 9, _heartWidth),new Vector3(5, 8, _heartWidth), new Vector3(5.4f,6.4f, _heartWidth), new Vector3(5.2f, 5, _heartWidth), // 12 - 18 back right
            new Vector3(-1, 8, _heartWidth), new Vector3(-3, 9, _heartWidth),new Vector3(-5, 8, _heartWidth), new Vector3(-5.4f,6.4f, _heartWidth), new Vector3(-5.2f, 5, _heartWidth) // back left
        };
        _triangles = new int[] {
            0, 1, 2, // front right
            0, 2, 3,
            0, 3, 4,
            0, 4, 5,
            0, 5, 6,
            0, 7, 1, // front left
            0, 8, 7,
            0, 9, 8,
            0, 10, 9,
            0, 11, 10, 
            12, 18, 17,// back right
            12, 17, 16,
            12, 16, 15,
            12, 15, 14,
            12, 14, 13,
            12, 13, 19, // back left
            12, 19, 20,
            12, 20, 21,
            12, 21, 22,
            12, 22, 23,
            // SIDES
            1, 13, 14, // right
            1, 14, 2,
            2, 14, 15,
            2, 15, 3,
            3, 15, 16,
            3, 16 ,4,
            4, 16, 17,
            4, 17, 5,
            5, 17, 18,
            5, 18, 6,
            6, 18, 0,
            0, 18, 12,
            1, 19, 13, // left
            1, 7, 19,
            7, 20, 19,
            7, 8, 20,
            8, 21, 20,
            8, 9, 21,
            9, 22, 21,
            9, 10, 22,
            10, 23, 22,
            10, 11, 23,
            11, 12, 23,
            0, 12, 11
        };
    }

    private void CreateUniqueCube()
    {
        _vertices = new Vector3[] {
            new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 1, -1), // Left
            new Vector3(0, 1, -1), new Vector3(0, 0, -1), new Vector3(0, 0, 0),

            new Vector3(0, 1, 0), new Vector3(1, 1, 0), new Vector3(0, 1, -1), // Top
            new Vector3(1, 1, 0), new Vector3(1, 1, -1), new Vector3(0, 1, -1),

            new Vector3(1, 1, -1), new Vector3(1, 1, 0), new Vector3(1, 0, 0), // Right
            new Vector3(1, 1, -1), new Vector3(1, 0, 0), new Vector3(1, 0, -1),

            new Vector3(1, 0, -1), new Vector3(1, 0, 0), new Vector3(0, 0, 0), // Bottom
            new Vector3(1, 0, -1), new Vector3(0, 0, 0), new Vector3(0, 0, -1),

            new Vector3(0, 1, -1), new Vector3(1, 1, -1), new Vector3(1, 0, -1), // Front
            new Vector3(1, 0, -1), new Vector3(0, 0, -1), new Vector3(0, 1, -1),

            new Vector3(1, 1, 0), new Vector3(0, 1, 0), new Vector3(1, 0, 0), // Back
            new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 0),
        };
        _triangles = new int[] {
            0, 1, 2, // left
            3, 4, 5,
            6, 7, 8, // top
            9, 10, 11,
            12, 13, 14, // right
            15, 16, 17,
            18, 19, 20, // bottom
            21, 22, 23,
            24, 25, 26, // front
            27, 28, 29,
            30, 31, 32, // back
            33, 34, 35
        };
    }

    private void UpdateMesh()
    {
        _mesh.Clear();
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _meshCollider.sharedMesh = _mesh;

    }

    private void CreateTetrahaedron()
    {
        _vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0.5f, 1, 0.5f), new Vector3(1, 0, 0), new Vector3(0.5f, 0, 1) };
        _triangles = new int[] { 0, 1, 2, 1, 0, 3, 1, 3, 2, 0, 2, 3 };
    }

    private void CreateUniqueTetrahaedron()
    {
        _vertices = new Vector3[] {
            new Vector3(0.5f, 1, 0.5f), new Vector3(1, 0, 0), new Vector3(0, 0, 0),
            new Vector3(0.5f, 1, 0.5f), new Vector3(0, 0, 0), new Vector3(0.5f, 0, 1),
            new Vector3(0.5f, 1, 0.5f), new Vector3(0.5f, 0, 1), new Vector3(1, 0, 0),
            new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0.5f, 0, 0)
        };
        _triangles = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    }

    private void CreateCoolWrongCube()
    {
        _vertices = new Vector3[] {
            new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(0, 0, 1), new Vector3(1, 0, 1), new Vector3(1, 1, 1), new Vector3(1, 1, 0), new Vector3(1, 0, 0) };
        _triangles = new int[] {
            0, 1, 2, // left
            2, 3, 0,
            1, 6, 2, // top
            6, 5, 2,
            2, 5, 4, // front
            4, 3, 2,
            5, 6, 7, // right
            7, 4, 5,
            4, 7, 0, // bottom
            0, 3, 4,
            6, 1, 0, // back
            0, 7, 6 };
    }

    private void CreateCube()
    {
        _vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 1, -1), new Vector3(0,0,-1), new Vector3(1, 0, -1), new Vector3(1, 1, -1), new Vector3(1, 1, 0), new Vector3(1,0,0) };
        _triangles = new int[] {
            0, 1, 2, // left
            2, 3, 0,
            1, 6, 2, // top
            6, 5, 2,
            2, 5, 4, // front
            4, 3, 2,
            5, 6, 7, // right
            7, 4, 5,
            4, 7, 0, // bottom
            0, 3, 4,
            6, 1, 0, // back
            0, 7, 6 };
    }
}
