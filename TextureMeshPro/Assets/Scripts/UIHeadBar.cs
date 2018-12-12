using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeadBar : MonoBehaviour {

    private ShowType _ShowType;
    public enum ShowType
    {
        ePlayerNormal,
        ePlayerPvp,
        eMonsterNormal,
    }

    [SerializeField]
    private GameObject m_txtParent;
    [SerializeField]
    private GameObject m_imgParent;
    [SerializeField]
    private GameObject m_titleParent;

    public struct HeadBarStruct
    {
        public Text textTitle;
        public Text textName;
        public Text textGuildName;
        public Text textChengHao;
        public Image imageChengHao;
        public Image imageTask;
        public GameObject progressbar;

        public Vector3 progressbarRelativePos;
        public Vector3 titleRelativePos;
        public Vector3 chengHaoImgRelativePos;
        public Vector3 chengHaoTxtRelativePos;
        public Vector3 nameRelativePos;
        public Vector3 guildNameRelativePos;
        public Vector3 taskRelativePos;

    }

    private Dictionary<long, HeadBarStruct> m_headBarDic = new Dictionary<long, HeadBarStruct>();
    private GameObject m_txtPrefab = null;
    private GameObject m_imgPrefab = null;
    private GameObject m_progressbar = null;

    private GameObject CreateProgressBar()
    {
        if (m_progressbar == null)
            m_progressbar = Resources.Load<GameObject>("progressbar");
        GameObject go = GameObject.Instantiate(m_progressbar);
        return go;
    }

    private Text CreateTxt()
    {
        if (m_txtPrefab == null)
            m_txtPrefab = Resources.Load<GameObject>("Text");
        GameObject go = GameObject.Instantiate(m_txtPrefab);
        return go.GetComponent<Text>();
    }
    private Image CreateImage()
    {
        if (m_imgPrefab == null)
            m_imgPrefab = Resources.Load<GameObject>("Image");
        GameObject go = GameObject.Instantiate(m_imgPrefab);
        return go.GetComponent<Image>();
    }

    public void Release(long dbid)
    {
        if(m_headBarDic.ContainsKey(dbid))
        {
            m_headBarDic.Remove(dbid);
        }
    }
    public void CreateHeadBar(long dbid,string name,string titlename,string guildname,Sprite taskSpt = null, ShowType showType = ShowType.ePlayerNormal)
    {
        _ShowType = showType;
        HeadBarStruct headBarStruct;
        if (!m_headBarDic.ContainsKey(dbid))
        {
            headBarStruct = new HeadBarStruct();
            headBarStruct.textTitle = CreateTxt();
            headBarStruct.textTitle.transform.SetParent(m_titleParent.transform);
            headBarStruct.textTitle.transform.localScale = Vector3.one;
            headBarStruct.textTitle.transform.localRotation = Quaternion.identity;
            headBarStruct.textTitle.transform.localPosition = Vector3.zero;
            if(string.IsNullOrEmpty(titlename))
            {
                headBarStruct.textTitle.gameObject.SetActive(false);
            }
            else
            {
                headBarStruct.textTitle.gameObject.SetActive(true);
                headBarStruct.textTitle.text = titlename;
            }

            headBarStruct.textGuildName = CreateTxt();
            headBarStruct.textGuildName.transform.SetParent(m_txtParent.transform);
            headBarStruct.textGuildName.transform.localScale = Vector3.one;
            headBarStruct.textGuildName.transform.localRotation = Quaternion.identity;
            headBarStruct.textGuildName.transform.localPosition = Vector3.zero;
            headBarStruct.textGuildName.alignment = TextAnchor.MiddleCenter;
            if (string.IsNullOrEmpty(guildname))
            {
                headBarStruct.textGuildName.gameObject.SetActive(false);
            }
            else
            {
                headBarStruct.textGuildName.gameObject.SetActive(true);
                headBarStruct.textGuildName.text = guildname;
            }

            headBarStruct.textName = CreateTxt();
            headBarStruct.textName.transform.SetParent(m_txtParent.transform);
            headBarStruct.textName.transform.localScale = Vector3.one;
            headBarStruct.textName.transform.localRotation = Quaternion.identity;
            headBarStruct.textName.transform.localPosition = Vector3.zero;
            if(string.IsNullOrEmpty(name))
            {
                headBarStruct.textName.gameObject.SetActive(false);
            }
            else
            {
                headBarStruct.textName.gameObject.SetActive(true);
                headBarStruct.textName.text = name;
            }

            headBarStruct.imageTask = CreateImage();
            headBarStruct.imageTask.transform.SetParent(m_imgParent.transform);
            headBarStruct.imageTask.transform.localScale = Vector3.one;
            headBarStruct.imageTask.transform.localRotation = Quaternion.identity;
            headBarStruct.imageTask.transform.localPosition = Vector3.zero;
            if(taskSpt == null)
            {
                headBarStruct.imageTask.gameObject.SetActive(false);
            }
            else
            {
                headBarStruct.imageTask.gameObject.SetActive(true);
                headBarStruct.imageTask.sprite = taskSpt;
                headBarStruct.imageTask.SetNativeSize();
            }

            headBarStruct.imageChengHao = CreateImage();
            headBarStruct.imageChengHao.transform.SetParent(m_imgParent.transform);
            headBarStruct.imageChengHao.transform.localScale = Vector3.one;
            headBarStruct.imageChengHao.transform.localRotation = Quaternion.identity;
            headBarStruct.imageChengHao.transform.localPosition = Vector3.zero;
            headBarStruct.imageChengHao.gameObject.SetActive(false);

            headBarStruct.textChengHao = CreateTxt();
            headBarStruct.textChengHao.transform.SetParent(m_txtParent.transform);
            headBarStruct.textChengHao.transform.localScale = Vector3.one;
            headBarStruct.textChengHao.transform.localRotation = Quaternion.identity;
            headBarStruct.textChengHao.transform.localPosition = Vector3.zero;
            headBarStruct.textChengHao.alignment = TextAnchor.MiddleCenter;
            headBarStruct.textChengHao.gameObject.SetActive(false);


            headBarStruct.progressbar = CreateProgressBar();
            headBarStruct.progressbar.transform.SetParent(m_imgParent.transform);
            headBarStruct.progressbar.transform.localScale = Vector3.one;
            headBarStruct.progressbar.transform.localRotation = Quaternion.identity;
            headBarStruct.progressbar.transform.localPosition = Vector3.zero;
            headBarStruct.progressbar.SetActive(false);

            m_headBarDic.Add(dbid, headBarStruct);

        }
        else
        {
            headBarStruct = m_headBarDic[dbid];
        }
        RefreshLayout(dbid);
    }
    public void SetMonsterTypeProgressBar(long dbid, float fillamount,bool isElite = false)
    {
        if(isElite)
        {
            //TODO change image sprite
        }
        else
        {
            //TODO change image sprite
        }
        HeadBarStruct headBarStruct = m_headBarDic[dbid];
        headBarStruct.progressbar.SetActive(true);
        headBarStruct.progressbar.transform.Find("Image").GetComponent<Image>().fillAmount = fillamount;
        RefreshLayout(dbid);
    }

    public void SetPlayerTypeProgressBar(long dbid, float fillamount, bool isTeam = false)
    {
        if (isTeam)
        {
            //TODO change image sprite
        }
        else
        {
            //TODO change image sprite
        }
        HeadBarStruct headBarStruct = m_headBarDic[dbid];
        headBarStruct.progressbar.SetActive(true);
        headBarStruct.progressbar.transform.Find("Image").GetComponent<Image>().fillAmount = fillamount;
        RefreshLayout(dbid);
    }

    public void SetTitle(long dbid,string titlename)
    {
        if(string.IsNullOrEmpty(titlename))
        {
            Debug.LogError("title is null");
            return;
        }
        HeadBarStruct headBarStruct = m_headBarDic[dbid];
        headBarStruct.textTitle.gameObject.SetActive(true);
        headBarStruct.textTitle.text = titlename;

        RefreshLayout(dbid);
    }
    
    //layout
    private void RefreshLayout(long dbid)
    {
        HeadBarStruct headBarStruct = m_headBarDic[dbid];
        switch (_ShowType)
        {
            case ShowType.ePlayerNormal:
                {
                    if(headBarStruct.textTitle.isActiveAndEnabled)
                    {
                        headBarStruct.textTitle.alignment = TextAnchor.MiddleRight;
                        headBarStruct.textName.alignment = TextAnchor.MiddleLeft;

                        float mus = headBarStruct.textTitle.preferredWidth - headBarStruct.textName.preferredWidth;
                        headBarStruct.textTitle.transform.localPosition = new Vector3(-headBarStruct.textTitle.rectTransform.sizeDelta.x / 2 + mus / 2, 0, 0);
                        headBarStruct.textName.transform.localPosition = new Vector3(headBarStruct.textName.rectTransform.sizeDelta.x / 2 + mus / 2, 0, 0);
                    }
                    else
                    {
                        headBarStruct.textName.alignment = TextAnchor.MiddleCenter;
                        headBarStruct.textName.transform.localPosition = Vector3.zero;
                    }
                  

                    if (headBarStruct.textGuildName.isActiveAndEnabled)
                    {
                        float y = headBarStruct.textName.preferredHeight + 5;
                        headBarStruct.textGuildName.transform.localPosition = new Vector3(0,y , 0);
                    }
                    if(headBarStruct.textChengHao.isActiveAndEnabled)
                    {
                        float y = headBarStruct.textGuildName.preferredHeight + headBarStruct.textName.preferredHeight + 5;
                        headBarStruct.textChengHao.transform.localPosition = new Vector3(0, y, 0);
                    }
                    if (headBarStruct.imageChengHao.isActiveAndEnabled)
                    {
                        float y = headBarStruct.textGuildName.preferredHeight + headBarStruct.textName.preferredHeight + 5;
                        headBarStruct.imageChengHao.transform.localPosition = new Vector3(0, y, 0);
                    }
                    if (headBarStruct.imageTask.isActiveAndEnabled)
                    {
                        float y = 0;
                        if(headBarStruct.imageChengHao.isActiveAndEnabled)
                        {
                            y = headBarStruct.imageChengHao.transform.localPosition.y + headBarStruct.imageChengHao.preferredHeight - headBarStruct.imageChengHao.rectTransform.rect.height / 2 + headBarStruct.imageTask.preferredHeight / 2;
                        }else if (headBarStruct.textChengHao.isActiveAndEnabled)
                        {
                            y = headBarStruct.textChengHao.transform.localPosition.y + headBarStruct.textChengHao.preferredHeight - headBarStruct.textChengHao.rectTransform.rect.height / 2 + headBarStruct.imageTask.preferredHeight / 2;
                        }
                        else if (headBarStruct.textGuildName.isActiveAndEnabled)
                        {
                            y = headBarStruct.textGuildName.transform.localPosition.y + headBarStruct.textGuildName.preferredHeight - headBarStruct.textGuildName.rectTransform.rect.height / 2 + headBarStruct.imageTask.preferredHeight / 2;
                        }
                        else
                        {
                            y = headBarStruct.textName.transform.localPosition.y + headBarStruct.textName.preferredHeight - headBarStruct.textName.rectTransform.rect.height / 2 + headBarStruct.imageTask.preferredHeight / 2;
                        }
                        headBarStruct.imageTask.transform.localPosition = new Vector3(0, y, 0);
                    }
                    break;
                }
            case ShowType.ePlayerPvp:
                {
                    headBarStruct.textGuildName.gameObject.SetActive(false);
                    headBarStruct.textChengHao.gameObject.SetActive(false);
                    headBarStruct.imageChengHao.gameObject.SetActive(false);
                    headBarStruct.imageTask.gameObject.SetActive(false); 
                    headBarStruct.progressbar.gameObject.SetActive(true);

                    headBarStruct.progressbar.transform.localPosition = new Vector3(0, 0, 0);
                    float y = headBarStruct.progressbar.GetComponent<Image>().preferredHeight / 2 ;
                    if( headBarStruct.textTitle.isActiveAndEnabled)
                    {
                        headBarStruct.textTitle.alignment = TextAnchor.MiddleRight;
                        headBarStruct.textName.alignment = TextAnchor.MiddleLeft;
                        float mus = headBarStruct.textTitle.preferredWidth - headBarStruct.textName.preferredWidth;
                        headBarStruct.textTitle.transform.localPosition = new Vector3(-headBarStruct.textTitle.rectTransform.sizeDelta.x / 2 + mus / 2, y, 0);
                        headBarStruct.textName.transform.localPosition = new Vector3(headBarStruct.textName.rectTransform.sizeDelta.x / 2 + mus / 2, y, 0);
                    }else
                    {
                        headBarStruct.textName.alignment = TextAnchor.MiddleCenter;
                        headBarStruct.textName.transform.localPosition = new Vector3(0, y, 0);
                    }
                   
                    break;
                }
            case ShowType.eMonsterNormal:
                {
                    headBarStruct.textGuildName.gameObject.SetActive(false);
                    headBarStruct.textChengHao.gameObject.SetActive(false);
                    headBarStruct.textTitle.gameObject.SetActive(false);
                    headBarStruct.imageChengHao.gameObject.SetActive(false);
                    headBarStruct.textName.gameObject.SetActive(false);
                    headBarStruct.progressbar.gameObject.SetActive(true);

                    if(headBarStruct.textName.isActiveAndEnabled)
                    {
                        headBarStruct.textName.alignment = TextAnchor.MiddleCenter;
                        headBarStruct.progressbar.transform.localPosition = new Vector3(0, 0, 0);
                        float y = headBarStruct.progressbar.GetComponent<Image>().preferredHeight / 2;
                        headBarStruct.textName.transform.localPosition = new Vector3(0, y, 0);
                    }
                  
                    if (headBarStruct.imageTask.isActiveAndEnabled)
                    {
                        if (headBarStruct.textName.isActiveAndEnabled)
                        {
                            float y = headBarStruct.textName.transform.localPosition.y + headBarStruct.textName.preferredHeight - headBarStruct.textName.rectTransform.rect.height / 2 + headBarStruct.imageTask.preferredHeight / 2;
                            headBarStruct.imageTask.transform.localPosition = new Vector3(0, y, 0);
                        }
                        else
                        {
                            float y = headBarStruct.progressbar.GetComponent<Image>().preferredHeight / 2 + headBarStruct.imageTask.preferredHeight / 2;
                            headBarStruct.imageTask.transform.localPosition = new Vector3(0, y, 0);
                        }
                           
                    }
                    break;
                }
        }
        headBarStruct.titleRelativePos = headBarStruct.textTitle.transform.position;
        headBarStruct.nameRelativePos = headBarStruct.textName.transform.position;
        headBarStruct.guildNameRelativePos = headBarStruct.textGuildName.transform.position;
        headBarStruct.taskRelativePos = headBarStruct.imageTask.transform.position;
        headBarStruct.chengHaoImgRelativePos = headBarStruct.imageChengHao.transform.position;
        headBarStruct.chengHaoTxtRelativePos = headBarStruct.textChengHao.transform.position;
        headBarStruct.progressbarRelativePos = headBarStruct.progressbar.transform.position;
        m_headBarDic[dbid] = headBarStruct;
    }
    public void SetGuildName(long dbid,string guildName)
    {
        if (string.IsNullOrEmpty(guildName))
        {
            Debug.LogError("guildName is null");
            return;
        }
        HeadBarStruct headBarStruct = m_headBarDic[dbid];
        headBarStruct.textGuildName.gameObject.SetActive(true);
        headBarStruct.textGuildName.text = guildName;

        RefreshLayout(dbid);
    }

    public void SetChengHao(long dbid, string chenghao)
    {
        if (string.IsNullOrEmpty(chenghao))
        {
            Debug.LogError("chenghao is null");
            return;
        }
        HeadBarStruct headBarStruct = m_headBarDic[dbid];
        headBarStruct.textChengHao.text = chenghao;
        headBarStruct.textChengHao.gameObject.SetActive(true);

        if (headBarStruct.imageChengHao.isActiveAndEnabled)
        {
            headBarStruct.imageChengHao.gameObject.SetActive(false);
        }
        RefreshLayout(dbid);
    }
    public void SetChengHao(long dbid, Sprite chenghao)
    {
        if (chenghao == null)
        {
            Debug.LogError("chenghao is null");
            return;
        }
        HeadBarStruct headBarStruct = m_headBarDic[dbid];
        headBarStruct.imageChengHao.sprite = chenghao;
        headBarStruct.textChengHao.gameObject.SetActive(true);

        if (headBarStruct.textChengHao.isActiveAndEnabled)
        {
            headBarStruct.textChengHao.gameObject.SetActive(false);
        }
            RefreshLayout(dbid);
    }

    public void SetTaskImg(long dbid, Sprite taskSpt)
    {
        if (taskSpt == null )
        {
            Debug.LogError("taskSpt is null");
            return;
        }
        HeadBarStruct headBarStruct = m_headBarDic[dbid];
        headBarStruct.imageTask.gameObject.SetActive(true);
        headBarStruct.imageTask.sprite = taskSpt;

        RefreshLayout(dbid);
    }
    public void UpdateEntities(long dbid,Vector3 postion)
    {
        Vector3 taskPos = m_headBarDic[dbid].taskRelativePos;
        Vector3 titlePos = m_headBarDic[dbid].titleRelativePos;
        Vector3 namePos = m_headBarDic[dbid].nameRelativePos;
        Vector3 guildPos = m_headBarDic[dbid].guildNameRelativePos;
        Vector3 progressPos = m_headBarDic[dbid].progressbarRelativePos;

        m_headBarDic[dbid].imageTask.transform.position = new Vector3(taskPos.x + postion.x, taskPos.y + postion.y, taskPos.z = postion.z);
        m_headBarDic[dbid].textTitle.transform.position = new Vector3(titlePos.x + postion.x, titlePos.y + postion.y, titlePos.z = postion.z);
        m_headBarDic[dbid].textName.transform.position = new Vector3(namePos.x + postion.x, namePos.y + postion.y, namePos.z = postion.z);
        m_headBarDic[dbid].textGuildName.transform.position = new Vector3(guildPos.x + postion.x, guildPos.y + postion.y, guildPos.z = postion.z);
        m_headBarDic[dbid].progressbar.transform.position = new Vector3(progressPos.x + postion.x, progressPos.y + postion.y, progressPos.z = postion.z);


    }

}
