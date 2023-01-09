const express = require('express')
const app = express()
const port = 5010

var jetcoinval = 0;

app.get('/', (req, res) => {
  res.send('To see your wallet, type \'getWallet/[name]\'. \r\n To see the current value of a Jetcoin, type \'coinValue\'.');
})

app.get('/getWallet/:name', (req, res) => {
  const name = req.params.name;
  res.send(name + '\'s wallet: 50 Jetcoins');
})

app.get('/coinValue', (req, res) => {
  res.send('Current value of Jetcoin: ' + jetcoinval + '.');
})

app.get('/sell', (req, res) => {
  if (jetcoinval > 0) {
    jetcoinval = jetcoinval - 0.5;
  }  
  res.send('Sold 1 Jetcoin');
})

app.get('/buy/:name', (req, res) => {
  jetcoinval = jetcoinval + 1;
  res.send('Bought 1 Jetcoin');
})

app.use((req,res,next)=> { // als laatste
    res.status(404).send("To see your wallet, type 'getWallet/[name]'. \r\n To see the current value of a Jetcoin, type 'coinValue'.");
    })

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`);
})
