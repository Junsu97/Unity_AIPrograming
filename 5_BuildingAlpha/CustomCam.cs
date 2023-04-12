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


            Vector3 dir = player.transform.position - transform.position;//ĳ���� ����

            //ī�޶���� ĳ���ͱ����� �Ÿ�
            float dis = Vector3.Distance(transform.position, player.transform.position);
            RaycastHit[] hits =
                Physics.RaycastAll(transform.position, dir.normalized, dis, 1);
            //ī�޶���� ĳ���ͱ����� �Ÿ��� ���̸� ��


            if (hits.Length == 0)
            {// �浹�� ������Ʈ�� ���ٸ�, ���ĸ���Ʈ�� ������Ʈ���� ���İ��� 1
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
                //// ĳ���Ϳ� ī�޶� ���̿� ������Ʈ�� �ִٸ� ���ĸ���Ʈ�� �߰�
                //// ���̿� �浹�� ������Ʈ�� ����Ʈ�� ���ԵǾ� �ִ��� �˻�
                //GameObject alphaObj = Alphalist.Find(o => (o.Equals(one.collider.gameObject)));

                //// ���� ����ó���� �߰��ؾ� �Ѵٸ�==���� ���̿� �浹�� ������Ʈ�� ����Ʈ�� ���°��.
                //if (alphaObj == null)
                //{   //�浹�� ������Ʈ�� ���ĸ���Ʈ�� �߰�
                //    Alphalist.Add(one.collider.gameObject);
                //    Color col = one.collider.GetComponent<MeshRenderer>().material.color;
                //    col.a = 0.2f;
                //    one.collider.GetComponent<MeshRenderer>().material.color = col;
                //}

            }
            /* ���İ� ó���Ǵ°��� ���ĸ���Ʈ�� �־��� ĳ���ʹ� �����̱� ������
             * ����ó�� �� ������Ʈ�� ���ÿ� �˻�
             */

            // ��������
            for (int i = 0; i < Alphalist.Count; i++)
            {
                GameObject tmp = null;
                // ������ �Ǿ�� �� ������Ʈ�� �ִ��� �˻�
                for (int j = 0; j < hits.Length; j++)
                {
                    if (Alphalist[i].NAME == hits[j].collider.gameObject.name)
                    {
                        tmp = hits[j].collider.gameObject;
                    }
                }

                if (tmp == null) // ���� �ִ� ���ĸ���Ʈ���� ���ܵ� ���ӿ�����Ʈ�� �ǹ�
                {
                    BuildingObj recoverObjs = Recoverlist.Find(o => o.Equals(Alphalist[i]));

                    // �̹� ��������Ʈ�� ���ԵǾ� �ִٸ�
                    if (recoverObjs != null)
                    {
                        continue; // ��Ƽ���� ������ ������ �ٽõ�
                    }

                    Color col = Alphalist[i].MAT.color;
                    col.a = 1f;
                    Alphalist[i].MAT.color = col;

                    Recoverlist.Add(Alphalist[i]);
                }
            }

            // Recoverlist�� �ִ� ������Ʈ�� Alphalist���� ����
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

    void LateUpdate() // �ڷ�ƾ���� �ϸ� ȿ�� ������  + Dictionary �� �ٲܰ�.
    {
       
    }
}
