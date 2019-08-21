# Spotify Status

## Environment

```
country=Россия
telegramBotApiKey={ключ от бота}
telegramBotApiKey={айди чата}
telegramTextYes={подпись к картинке да}
telegramTextNo={подпись к картинке нет}
giphyApiKey={ключ от гифи}
giphyTextYes={тег для поиска картинки да}
giphyTextNo={тег для поиска картинки нет}
dryRun={не отправлять сообщение в телегу}
```

## RUN

```
docker build -t xxx .

docker run -d 
 -e country="Россия"\ 
 -e telegramBotApiKey="{ключ от бота}",\ 
 -e telegramChannel="{айди чата}",\ 
 -e telegramTextYes="Да",\ 
 -e telegramTextNo="Нет",\ 
 -e giphyApiKey="{ключ от гифи}",\ 
 -e giphyTextYes="Yes",\ 
 -e giphyTextNo="No",\ 
 -e dryRun=true\ 
 xxx xxx
```