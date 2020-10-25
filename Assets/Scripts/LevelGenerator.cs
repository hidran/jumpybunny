using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Sample blocks from where to create new blocks
  public  List<LevelBlock> legoBlocks = new List<LevelBlock>();
    // Blocks added to the game
    List<LevelBlock> currentBlocks = new List<LevelBlock>();

    public Transform initialPoint;

    private static LevelGenerator _sharedInstance;
    public static LevelGenerator sharedInstance
    {
        get
        {
            return _sharedInstance;
        }
       
    }
    private void Awake()
    {
        _sharedInstance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewBlock()
    {
        // 0 1 2 3 4
        int randNumber = Random.Range(0, legoBlocks.Count - 1);
        //var myBlock = new LevelBlock();
      var  block =  Instantiate( legoBlocks[randNumber]);
        block.transform.SetParent(this.transform);
        Vector3 blockPosition = Vector3.zero;
        if(currentBlocks.Count == 0)
        {
            blockPosition = initialPoint.position;
        } else
        {
            int lastBlockPos = currentBlocks.Count - 1;
            blockPosition = currentBlocks[lastBlockPos].exitPoint.position;
        }
        block.transform.position = blockPosition;
        currentBlocks.Add(block);
    }
}
