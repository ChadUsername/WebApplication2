# AsiaYoPreTestProduct API

這是一個簡單的匯率轉換 API，可以將指定貨幣的金額轉換成另一個貨幣的金額。
目前只含"TWD"、"JPY"、"USD"

由於我是使用正規表示式去除數字以外的東西，所以傳入amount如果是含英數之字串也會通過。

於此需確認幾件事情
1.討論amount是否可以傳入純數字。
2.確認貨幣符號是否只有一個，不會出現NT $ 這類型的。
3.如果實在不行，也不能忽視其錯誤改寫法抓第一個數字之後的字串，判別裡面是否只有數字。

## 如何使用

### 安裝

在使用此 API 之前，請確保已安裝 [.NET Core](https://dotnet.microsoft.com/download)。

### 下載專案

git clone https://github.com/ChadUsername/WebApplication2.git

### 執行專案

cd AsiaYoPreTestProduct
dotnet run
API 將運行在 'http://localhost:5000' 上。

### 使用 API

可以使用任何 API 測試工具或 HTTP 客戶端來測試這個 API，例如 [Postman](https://www.postman.com/) 或瀏覽器。

#### GET /api/AsiaYoPreTestProduct

將指定貨幣的金額轉換成另一個貨幣的金額。

##### 參數

- 'source' (string)：要轉換的原始貨幣代碼 (例如 "TWD")
- 'target' (string)：目標貨幣代碼 (例如 "USD")
- 'amount' (string)：要轉換的金額 (例如 "1000")

##### 範例

GET http://localhost:5000/api/AsiaYoPreTestProduct?source=TWD&target=USD&amount=1000

##### 回傳值

成功時：

json
{
  "msg": "成功",
  "amount": "$1000.00"
}

失敗時（傳入參數為空值）：
{
  "msg": "傳入參數請勿空值"
}

失敗時（非數字金額）：
{
  "msg": "傳入參數amount為非數字"
}

失敗時（無效貨幣代碼）：
{
  "msg": "無此匯率"
}

失敗時（Exception時）：
{
  "msg": "失敗"
}
