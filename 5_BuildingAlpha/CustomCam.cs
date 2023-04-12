using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCam : MonoBehaviour
{
    public class BuildingObj 
    {
        public Color originCol;
        public GameObject obj;
        private Material mat;
        public Material MAT
        {
            get
            {
                if (mat == null)
                {
                    mat = obj.GetComponent<MeshRenderer>().material;
                }

                return mat;
            }
        }

        public string NAME
        {
            get
            {
                return obj.name;
            }
        }
    }


    public GameObject player;
    //List<GameObject> Alphalist = new List<GameObject>();
    //List<GameObject> Recoverlist = new List<GameObject>();
    List<BuildingObj> Alphalist = new List<BuildingObj>();
    List<BuildingObj> Recoverlist = new List<BuildingObj>();


    IEnumerator Start()
    {
        StartCoroutine(BuildngAlpha());
        yield return null;
    }

    public void AddAlphalist(BuildingObj obj)
    {
        BuildingObj alphaObj = FindAlphalist(obj);
        if(alphaObj == null)
        {
            Alphalist.Add(obj);
            Color col = obj.MAT.color;
            col.a = 0.2f;
            obj.MAT.color = col;
        }
    }

    public BuildingObj FindAlphalist(BuildingObj obj)
    {
        BuildingObj findObj = Alphalist.Find(o=>(o.NAME.Equals(obj.NAME)));
        return findObj;
    }
    IEnumerator BuildngAlpha()
    {
        
        for(; ;)
        {
            yield return new WaitForSeconds(0.1f);


            Vector3 dir = player.transform.position - transform.position;//캐릭터 방향

            //카메라부터 캐릭터까지의 거리
            float dis = Vector3.Distance(transform.position, player.transform.position);
            RaycastHit[] hits =
                Physics.RaycastAll(transform.position, dir.normalized, dis, 1);
            //카메라부터 캐릭터까지의 거리에 레이를 쏨


            if (hits.Length == 0)
            {// 충돌한 오브젝트가 없다면, 알파리스트의 오브젝트들의 알파값을 1
                for (int i = 0; i < Alphalist.Count; i++)
                {
                    //Color col = Alphalist[i].GetComponent<MeshRenderer>().material.color;
                    Color col = Alphalist[i].MAT.color;
                    col.a = 1f;
                    Alphalist[i].MAT.color = col;
                }
                Alphalist.Clear();
                continue;
            }


            foreach (var one in hits)
            {
               // AddAlphalist(one.collider.gameObject);
                //// 캐릭터와 카메라 사이에 오브젝트가 있다면 알파리스트에 추가
                //// 레이와 충돌한 오브젝트가 리스트에 포함되어 있는지 검사
                //GameObject alphaObj = Alphalist.Find(o => (o.Equals(one.collider.gameObject)));

                //// 새로 알파처리를 추가해야 한다면==현재 레이와 충돌한 오브젝트가 리스트에 없는경우.
                //if (alphaObj == null)
                //{   //충돌한 오브젝트를 알파리스트에 추가
                //    Alphalist.Add(one.collider.gameObject);
                //    Color col = one.collider.GetComponent<MeshRenderer>().material.color;
                //    col.a = 0.2f;
                //    one.collider.GetComponent<MeshRenderer>().material.color = col;
                //}

            }
            /* 알파가 처리되는것은 알파리스트에 넣었고 캐릭터는 움직이기 때문에
             * 복원처리 할 오브젝트를 동시에 검사
             */

            // 복원구현
            for (int i = 0; i < Alphalist.Count; i++)
            {
                GameObject tmp = null;
                // 복원이 되어야 할 오브젝트가 있는지 검사
                for (int j = 0; j < hits.Length; j++)
                {
                    if (Alphalist[i].NAME == hits[j].collider.gameObject.name)
                    {
                        tmp = hits[j].collider.gameObject;
                    }
                }

                if (tmp == null) // 원래 있던 알파리스트에서 제외된 게임오브젝트를 의미
                {
                    BuildingObj recoverObjs = Recoverlist.Find(o => o.Equals(Alphalist[i]));

                    // 이미 복원리스트에 포함되어 있다면
                    if (recoverObjs != null)
                    {
                        continue; // 컨티뉴를 만나면 루프를 다시돔
                    }

                    Color col = Alphalist[i].MAT.color;
                    col.a = 1f;
                    Alphalist[i].MAT.color = col;

                    Recoverlist.Add(Alphalist[i]);
                }
            }

            // Recoverlist에 있는 오브젝트를 Alphalist에서 제거
            BuildingObj[] recoverArray = Recoverlist.ToArray();
            for (int i = 0; i < recoverArray.Length; i++)
            {
                BuildingObj findObj = Alphalist.Find(o => (o.Equals(recoverArray[i])));
                if (findObj != null)
                {
                    Alphalist.Remove(findObj);
                }
            }
            Recoverlist.Clear();

            yield return null;
        }

    }

    void LateUpdate() // 코루틴으로 하면 효율 좋아짐  + Dictionary 로 바꿀것.
    {
       
    }
}
