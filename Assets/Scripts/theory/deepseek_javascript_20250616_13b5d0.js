const express = require('express');
const puppeteer = require('puppeteer');
const path = require('path');
const app = express();
const port = 3000;

// Раздаем статические файлы из папки проекта
app.use(express.static(path.join(__dirname)));

// CORS для Unity
app.use((req, res, next) => {
  res.header('Access-Control-Allow-Origin', '*');
  next();
});

app.get('/screenshot', async (req, res) => {
  try {
    const browser = await puppeteer.launch({
      headless: "new",
      args: ['--no-sandbox', '--disable-web-security']
    });
    
    const page = await browser.newPage();
    
    // Загрузка ЛОКАЛЬНОГО файла
    await page.goto(`file://${path.join(__dirname, 'index.html')}`, {
      waitUntil: 'networkidle0',
      timeout: 10000
    });
    
    // Ожидание загрузки контента (при необходимости)
    await page.waitForTimeout(1000);
    
    const screenshot = await page.screenshot({
      type: 'jpeg',
      quality: 90
    });
    
    await browser.close();
    
    res.set('Content-Type', 'image/jpeg');
    res.send(screenshot);
    
  } catch (error) {
    console.error('Error:', error);
    res.status(500).send('Error: ' + error.message);
  }
});

app.listen(port, () => {
  console.log(`Local Server running at http://localhost:${port}`);
  console.log(`Access HTML: file://${path.join(__dirname, 'index.html')}`);
  console.log(`Screenshot: http://localhost:${port}/screenshot`);
});