using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
     public Vector3[] points;
     public Vector3[] phase1points;
     public Vector3[] phase2points;
     public int point_number = 0;
     public Vector3 current_target;

     public float tolerance;
     public float speed;
     public float delay_time;

     private float delay_start;

     public bool automatic;
     public bool activate = true;

    //  public static MoveBackAndForth instance;

     void Start()
     {
        // Create instance
        // if(instance == null)
        // {
        //     instance = this;
        // } else {
        //     Destroy(gameObject);
        // }
        if(points.Length > 0)
        {
            current_target = points[0];
        }
        tolerance = speed * Time.deltaTime;
     }

     void Update()
     {
         if(activate){
            if(transform.position != current_target)
            {
                MovePlatform();
            }
            else
            {
                UpdateTarget();
            }    
         }

     }

     void MovePlatform()
     {
         Vector3 heading = current_target - transform.position;
         transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
         if(heading.magnitude < tolerance)
         {
             transform.position = current_target;
             delay_start = Time.time;
         }
     }

     void UpdateTarget()
     {
         if (automatic)
         {
             if(Time.time - delay_start > delay_time)
             {
                 NextPlatform();
             }
         }
     }

     public void NextPlatform()
     {
         point_number++;
         if(point_number >= points.Length)
         {
             point_number = 0;
         }
         current_target = points[point_number];
     }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MoveBackAndForth : MonoBehaviour
// {
//      public Vector3[] points;
//      public Vector3[] phase1points;
//      public Vector3[] phase2points;
//      public int point_number = 0;
//      public Vector3 current_target;

//      public float tolerance;
//      public float speed;
//      public float delay_time;

//      private float delay_start;

//      public bool automatic;
//      public bool activate = true;

//      public static MoveBackAndForth instance;

//      void Start()
//      {
//         // Create instance
//         if(instance == null)
//         {
//             instance = this;
//         } else {
//             Destroy(gameObject);
//         }


//         if(points.Length > 0)
//         {
//             current_target = points[0];
//         }
//         tolerance = speed * Time.deltaTime;
//      }

//      void Update()
//      {
//          if(activate){
//             if(transform.position != current_target)
//             {
//                 MovePlatform();
//             }
//             else
//             {
//                 UpdateTarget();
//             }    
//          }

//      }

//      void MovePlatform()
//      {
//          Vector3 heading = current_target - transform.position;
//          transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
//          if(heading.magnitude < tolerance)
//          {
//              transform.position = current_target;
//              delay_start = Time.time;
//          }
//      }

//      void UpdateTarget()
//      {
//          if (automatic)
//          {
//              if(Time.time - delay_start > delay_time)
//              {
//                  NextPlatform();
//              }
//          }
//      }

//      public void NextPlatform()
//      {
//          point_number++;
//          if(point_number >= points.Length)
//          {
//              point_number = 0;
//          }
//          current_target = points[point_number];
//      }
     
// }
