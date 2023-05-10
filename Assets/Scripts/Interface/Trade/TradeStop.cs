public class TradeStop : ButtonTemplate
{
    public void OnMouseDown()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
