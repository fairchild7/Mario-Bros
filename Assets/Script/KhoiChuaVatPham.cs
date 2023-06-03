using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhoiChuaVatPham : MonoBehaviour
{
    private float DoNayCuaKhoi = 0.5f;
    private float TocDoNay = 4f;
    private bool DuocNay = true;
    private Vector3 ViTriLucDau;

    //Variable for containing item (mushroom, star..)
    public bool ChuaNam = false;
    public bool ChuaXu = false;
    public bool ChuaSao = false;

    //Coin's number
    public int SoLuongXu = 1;

    //Get mario's current level
    GameObject Mario;

    private void Awake()
    {
        Mario = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "VaCham" && collision.contacts[0].normal.y > 0)
        {
            ViTriLucDau = transform.position;
            KhoiNayLen();
        }
    }

    void KhoiNayLen()
    {
        if (DuocNay)
        {
            StartCoroutine(KhoiNay());
            DuocNay = false;
            if (ChuaNam)
            {
                NamVaHoa();
            }
            else if (ChuaXu)
            {
                HienThiXu();
            }
        }
    }

    IEnumerator KhoiNay()
    {
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + TocDoNay * Time.deltaTime);
            if (transform.localPosition.y >= ViTriLucDau.y + DoNayCuaKhoi) break;
            yield return null;
        }
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - TocDoNay * Time.deltaTime);
            if (transform.localPosition.y <= ViTriLucDau.y) break;
            Destroy(gameObject);
            GameObject KhoiRong = (GameObject)Instantiate(Resources.Load("Prefabs/KhoiTrong"));
            KhoiRong.transform.position = ViTriLucDau;
            yield return null;
        }
    }

    void NamVaHoa()
    {
        int CapDoHienTai = Mario.GetComponent<MarioScript>().CapDo;
        GameObject Nam = null;
        if (CapDoHienTai == 0) Nam = (GameObject)Instantiate(Resources.Load("Prefabs/NamAn"));
        else Nam = (GameObject)Instantiate(Resources.Load("Prefabs/Hoa"));
        Mario.GetComponent<MarioScript>().TaoAmThanh("PowerUp");
        Nam.transform.SetParent(this.transform.parent);
        Nam.transform.localPosition = new Vector2(ViTriLucDau.x, ViTriLucDau.y + 1f);
    }

    void HienThiXu()
    {
        GameObject DongXu = (GameObject)Instantiate(Resources.Load("Prefabs/XuNay"));
        DongXu.transform.SetParent(this.transform.parent);
        DongXu.transform.localPosition = new Vector2(ViTriLucDau.x, ViTriLucDau.y + 1f);
        StartCoroutine(XuNayLen(DongXu));
    }

    IEnumerator XuNayLen(GameObject DongXu)
    {
        float DoNayXu = 10f;
        while (true)
        {
            DongXu.transform.localPosition = new Vector2(DongXu.transform.localPosition.x, DongXu.transform.localPosition.y + TocDoNay * Time.deltaTime);
            if (DongXu.transform.localPosition.y >= ViTriLucDau.y + DoNayXu) break;
            yield return null;
        }
        while (true)
        {
            DongXu.transform.localPosition = new Vector2(DongXu.transform.localPosition.x, DongXu.transform.localPosition.y - TocDoNay * Time.deltaTime);
            if (DongXu.transform.localPosition.y <= ViTriLucDau.y) break;
            Destroy(DongXu.gameObject);
            
            yield return null;
        }
    }
}
