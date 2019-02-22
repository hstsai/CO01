using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml; // XML文件
using System.Xml.Linq; // LINQ TO XML

namespace COD01
{
  public partial class Form1 : Form
  {
    XElement xe; // 讀取XML檔案

    public Form1()
    {
      InitializeComponent();
    }

    // 讀取XML檔案
    private void button1_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK) // 開檔對話窗
      {
        treeView1.BeginUpdate(); // 開啟更新狀態，暫停畫面重劃
        treeView1.Nodes.Clear(); // 清除treeView1的所有節點
        xe = XElement.Load(openFileDialog1.FileName); // 讀入XML文件檔
        var trn = new TreeNode(xe.Name.ToString()); // 以XML文件根節點名稱建立TreeView節點(或TreeNode物件) https://msdn.microsoft.com/zh-tw/library/system.windows.forms.treeview(v=vs.110).aspx
        treeView1.Nodes.Add(trn); // 新增TreeView控制項的根節點
        AddNode(xe.Elements(), trn); // 呼叫遞迴函數來新增節點
        treeView1.EndUpdate(); // 結束更新狀態，開始重劃畫面
        treeView1.ExpandAll(); // 開啟所有節點

        button2.Enabled = true; // 啟用匯出按鈕
        button3.Enabled = true; // 啟用上移按鈕
        button4.Enabled = true; // 啟用下移按鈕
        button5.Enabled = true; // 啟用新增按鈕
        button6.Enabled = true; // 啟用刪除按鈕
      }
    }

    // 新增TreeView節點遞迴函數
    private void AddNode(IEnumerable<XElement> xes, TreeNode treeNode)
    {
      foreach (XElement xn in xes) // 取出XML所有節點
      {
        var tn = new TreeNode(xn.Name.ToString()); // 建立TreeNode物件
        treeNode.Nodes.Add(tn); // 新增TreeView控制項的節點

        if (xn.Elements().Count() > 0) // 還有子節點，繼續
        {
          AddNode(xn.Elements(), tn);  // 呼叫遞迴函數
        }
        else
        {
          tn.Nodes.Add(xn.Value.ToString()); // 沒有子節點則回傳值
        }
      }
    }

    // 上移事件－針對TreeView節點
    private void button3_Click(object sender, EventArgs e)
    {
      var tn = treeView1.SelectedNode; // 取得選取節點
      if (tn != null && tn.Parent != null) // 沒有選定或選定為根節點
      {
        while (tn.Text != "book") // 向上找出book節點
        {
          tn = tn.Parent;
        }

        var pn = tn.PrevNode; // 取得前一節點
        if (pn != null) // 第一個book節點無法上移
        { 
          treeView1.BeginUpdate(); // 開啟更新狀態，暫停畫面重劃
          tn.Parent.Nodes.Remove(pn); // 刪除前節點
          tn.Parent.Nodes.Insert(tn.Parent.Nodes.IndexOf(tn) + 1, pn); // 插入目前節點之後
          treeView1.EndUpdate(); // 結束更新狀態，開始重劃畫面
        }
      }
    }

    // 下移事件－針對TreeView節點
    private void button4_Click(object sender, EventArgs e)
    {
      var tn = treeView1.SelectedNode; // 取得選取節點
      if (tn != null && tn.Parent != null) // 沒有選定或選定為根節點
      {
        while (tn.Text != "book") // 向上找出book節點
        {
          tn = tn.Parent;
        }

        var nn = tn.NextNode; // 取得下一節點
        if (nn != null) // 最後一個book節點無法下移
        {
          treeView1.BeginUpdate(); // 開啟更新狀態，暫停畫面重劃
          tn.Parent.Nodes.Remove(nn); // 刪除後節點
          tn.Parent.Nodes.Insert(tn.Parent.Nodes.IndexOf(tn), nn); // 插入目前節點之前
          treeView1.EndUpdate(); // 結束更新狀態，開始重劃畫面
        }
      }
    }

    // 新增事件
    private void button5_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK) // 開檔對話窗
      {
        var xenew = XElement.Load(openFileDialog1.FileName); // 讀入XML文件檔
        foreach (XElement xn in xenew.Elements("book")) // 由新XML文件取出節點
        {
          var xo = from x in xe.Elements("book") // 篩選舊文件重複節點
                   where x.Element("book_id").Value.Equals(xn.Element("book_id").Value)
                   select x;             

          if (xo.Count() > 0) // book_id重複
          {
            if (MessageBox.Show(xn.Element("book_id").Value + "重複，確認覆蓋嗎？", "XML瀏覽器", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) // 提示重複對話窗
            {
              xo.First().ReplaceWith(xn); // 只有一個重複
            }
          }
          else
          {
            xe.Add(xn); // 新增XElement節點
          }
        }

        treeView1.BeginUpdate(); // 開啟更新狀態，暫停畫面重劃
        treeView1.Nodes.Clear(); // 清除treeView1的所有節點，重建treeView1節點
        var trn = new TreeNode(xe.Name.ToString()); // 以XML文件根節點名稱建立TreeView節點
        treeView1.Nodes.Add(trn); // 新增TreeView控制項的根節點
        AddNode(xe.Elements(), trn); // 呼叫遞迴函數來新增節點
        treeView1.EndUpdate(); // 結束更新狀態，開始重劃畫面
        treeView1.ExpandAll(); // 開啟所有節點
      }
    }

    // 刪除事件
    private void button6_Click(object sender, EventArgs e)
    {
      var tn = treeView1.SelectedNode; // 取得選取節點
      if (tn != null && tn.Parent != null) // 沒有選定或選定為根節點
      {
        while (tn.Text != "book") // 向上找出TreeNode的book節點
        {
          tn = tn.Parent;
        }
        var tid = (from t in tn.Nodes.OfType<TreeNode>()
                  where t.Text.Contains("book_id")
                  select t.FirstNode.Text).First();
        var xo = (from x in xe.Elements("book") // 找出舊XML文件book_id節點
                 where x.Element("book_id").Value.Equals(tid)
                 select x).First();
        if (MessageBox.Show("確認要刪除" + xo.Element("book_title").Value + "(" + tid + ")嗎？", "XML瀏覽器", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) // 提示刪除對話窗
        {
          xo.Remove(); // 只有一個重複
        }

        treeView1.BeginUpdate(); // 開啟更新狀態，暫停畫面重劃
        treeView1.Nodes.Clear(); // 清除treeView1的所有節點，重建treeView1節點
        var trn = new TreeNode(xe.Name.ToString()); // 以XML文件根節點名稱建立TreeView節點
        treeView1.Nodes.Add(trn); // 新增TreeView控制項的根節點
        AddNode(xe.Elements(), trn); // 呼叫遞迴函數來新增節點
        treeView1.EndUpdate(); // 結束更新狀態，開始重劃畫面
        treeView1.ExpandAll(); // 開啟所有節點
      }
    }

    // 寫回XML檔案
    private void button2_Click(object sender, EventArgs e)
    {
      if (saveFileDialog1.ShowDialog() == DialogResult.OK) // 存檔對話窗
      {
        xe.Save(saveFileDialog1.FileName); // 匯出舊XML文件
      }
    }
  }
}
