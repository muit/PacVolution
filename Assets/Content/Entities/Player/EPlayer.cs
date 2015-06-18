using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using InControl;

public class EPlayer : Entity {

    public Color color;
    public int mass = 1;

    [Header("Attributes")]
    public float speed = 150.0f;
    public float stopDamp = 4.0f;
    public float changeCubeDelay = 0.5f;

    private CircleCollider2D cubeDetection;
    private CircleCollider2D collider;
    private List<Cube> nearCubes = new List<Cube>();
    [System.NonSerialized]
    public List<Cube> usedCubes = new List<Cube>();
    [System.NonSerialized]
    public List<Cube> removableCubes = new List<Cube>();

    private List<Collider2D> nearWalls = new List<Collider2D>();

	void Start () {
        base.Start();

        collider = GetComponent<CircleCollider2D>();
        cubeDetection = transform.FindChild("Detection").GetComponent<CircleCollider2D>();

        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        if (tno.isMine)
            Game.Get().controlledPlayer = this;

        AddMass(0);

        if (!Application.isEditor && !Game.IsMobile())
        {
            Game.Get().inControl.gameObject.SetActive(false);
        }
	}

    void Update()
    {
        if (!tno.isMine)
            return;

        if (Application.isEditor || Game.IsMobile())
        {
            InputDevice device = InputManager.ActiveDevice;
            Move(device.LeftStickX, device.LeftStickY);
        }
	}

    void Move(float h, float v) {
        if (h != 0f || v != 0f) {
            body2D.velocity = (new Vector2(h, v)) * speed * Time.deltaTime;
        } else {
            body2D.velocity = Vector2.Lerp(body2D.velocity, Vector2.zero, Time.deltaTime * stopDamp);
        }
    }

    [TNet.RFC(1)]
    void AddMass(int amount = 1) {
        mass += amount;

        float radius = Mathf.Sqrt(mass/Mathf.PI)/2;
        cubeDetection.radius = radius;
        collider.radius = radius;
    }

    public void SelectCube(Cube cube, bool value = true)
    {
        if (value)
        {
            if (cube.player == null)
            {
                cube.Select(this, color);
            }
            else if(cube.player != null && cube.player != this){
                cube.player.MoveCube(cube, this);
            }
        } else {
            cube.Select(null, Color.white);
        }
    }

    public void MoveCube(Cube oldCube, EPlayer newOldCubeOwner = null, Cube newCube = null){
        if(!newCube)
            newCube = nearCubes.Find(x => x.player != this);
        
        Color color = (newOldCubeOwner) ? newOldCubeOwner.color : Color.white;

        newOldCubeOwner.SelectCube(oldCube);
        SelectCube(newCube);
    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if (tno.isMine)
        {
            Cube cube = col.GetComponent<Cube>();
            if (cube)
            {
                nearCubes.Add(cube);
                if (cube.player != this)
                {
                    if (usedCubes.Count < mass)
                    {
                        SelectCube(cube);
                    }
                    else if (removableCubes.Count > 0)
                    {
                        Cube removableCube = removableCubes.Find(x => !nearCubes.Contains(x));
                        if (removableCube)
                        {
                            SelectCube(cube);
                            SelectCube(removableCube, false);
                        }
                    }
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (tno.isMine)
        {
            Cube cube = col.GetComponent<Cube>();
            if (cube)
            {
                nearCubes.Remove(cube);
            }
        }
    }
}
