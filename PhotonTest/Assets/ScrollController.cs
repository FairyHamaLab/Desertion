using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
public class ScrollController :MonoBehaviour
{

    public RectTransform prefab = null;
    private float total_height = 0;
    private  Text bt;
    private Text last = null;
    void Start()
    {
        SizeRe.sc = this;
      //  tag = null;
    }
      
   public  void AddChat(string player_name,string chat_text,Color color)
    {
    
       //とりあえず、適当なところにTextを生成
        var item = GameObject.Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity) as RectTransform;
       //自分を親に設定
        item.SetParent(transform, false);
       //チャットを設定
        var text = item.GetComponentInChildren<Text>();
        text.text = player_name +":"+ chat_text;
        //色を設定
        text.color = color;
       //現在、制作途中のテキストボックスへ設定
        bt = text;
    }
   public void AddTotal(float size)
   {
       //ポジション
       float pos = size *-0.5F;
       //テキストサイズ構造体
       RectTransform textrec = bt.GetComponent<RectTransform>();
       //一個前のテキストボックスが空（最初のテキストボックス）は無視
         if (last != null){
             //一個前のテキストボックスをもとに、位置を算出
          pos = last.GetComponent<RectTransform>().sizeDelta.y *-0.5F+ last.GetComponent<RectTransform>().localPosition.y + size *-0.5F;
         }
       //位置を設定
      textrec.anchoredPosition = new Vector3(7 + prefab.rect.width / 2, pos, 0);
       //自分を一個前とする
      last = bt;
       //スクロールフィールドの拡張
       if (GetComponent<RectTransform>().rect.height < (pos + size *-0.5F)*-1)
       {
           //sizeDeltaから変更しないといけないらしい
           Vector2 sd = GetComponent<RectTransform>().sizeDelta;
           //大きさを再設定
           sd.y = (pos + size * -0.5F) * -1 + 5;
           GetComponent<RectTransform>().sizeDelta = sd;
           //スクロールバーを最後に
           this.GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 0;
       }
        

   }
}