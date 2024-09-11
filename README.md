# ElasticSearch API ile Entegrasyon

Bu proje, ElasticSearch ile bir .NET API kullanarak CRUD işlemleri gerçekleştirmektedir. API, ElasticSearch veritabanında kullanıcıları yönetmek için gerekli işlemleri sağlar: indeks oluşturma, kullanıcı ekleme/güncelleme, kullanıcı getirme ve silme.

## API Endpoint'leri

- `POST /create-index`: ElasticSearch'te belirtilen bir indeks oluşturur (varsa tekrar oluşturmaz).
- `POST /add-user`: ElasticSearch indeksine yeni bir kullanıcı ekler veya mevcut bir kullanıcıyı günceller.
- `POST /update-user`: Var olan bir kullanıcıyı günceller.
- `POST /get-user/{key}`: Anahtar (key) ile bir kullanıcıyı getirir.
- `POST /get-all-users`: ElasticSearch'teki tüm kullanıcıları getirir.
- `POST /delete-user/{key}`: Anahtar (key) ile bir kullanıcıyı siler.
- `POST /delete-all`: ElasticSearch'teki tüm kullanıcıları siler.

## Gereksinimler

- Docker
- .NET 8
- ElasticSearch (Docker üzerinden ayarlanmıştır)
- Kibana (ElasticSearch'ü izlemek için)

## Kurulum Adımları

### 1. Projeyi Klonlayın

```bash
git clone https://github.com/kullanici-adi/proje-adi.git
cd proje-adi
```

### 2. Docker Kurulumu
Docker’ın sisteminizde kurulu ve çalışır durumda olduğundan emin olun.

Projenin kök dizininde docker-compose.yml dosyası bulunmaktadır. Bu dosya, ElasticSearch ve Kibana servislerinin ayarlarını içerir.

ElasticSearch ve Kibana’yı başlatmak için aşağıdaki komutu terminalde çalıştırın:

```bash
docker-compose up
```
Bu komut ile ElasticSearch http://localhost:9200, Kibana ise http://localhost:5601 adreslerinde çalışacaktır.

### 3. Uygulamayı Çalıştırma

Proje dizinine giderek uygulamayı çalıştırmak için aşağıdaki komutu kullanabilirsiniz:

```bash
dotnet run
```

### 4. ElasticSearch ve Kibana Kullanımı

ElasticSearch ve Kibana, Docker konteynerleri üzerinden çalışmaktadır:

ElasticSearch'ü kontrol etmek için: http://localhost:9200
Kibana'ya erişmek ve ElasticSearch üzerindeki işlemleri izlemek için: http://localhost:5601
Bu araçlar üzerinden indekslerinizi, belgelerinizi ve diğer ElasticSearch verilerinizi yönetebilir, Kibana'nın grafiksel arayüzü ile verilerinizi analiz edebilirsiniz.


## API Kullanımı
### 1. Index Oluşturma

ElasticSearch'te yeni bir indeks oluşturmak için:
```bash
POST http://localhost:5000/create-index
Body: 
{
  "indexName": "index-adi"
}
```

### 2. Kullanıcı Ekleme
ElasticSearch'e yeni bir kullanıcı eklemek veya mevcut bir kullanıcıyı güncellemek için:

```bash
POST http://localhost:5000/add-user
Body:
{
  "id": "1",
  "name": "John Doe",
  "email": "john.doe@example.com"
}
```

### 3. Kullanıcı Getirme
Anahtar (key) ile bir kullanıcıyı almak için:

```bash
POST http://localhost:5000/get-user/{key}
```

### 4. Tüm Kullanıcıları Getirme
ElasticSearch'teki tüm kullanıcıları getirmek için:

```bash
POST http://localhost:5000/get-all-users
```

### 5. Kullanıcı Silme
Anahtar (key) ile bir kullanıcıyı silmek için:

```bash
POST http://localhost:5000/delete-user/{key}
```

### 6. Tüm Kullanıcıları Silme
ElasticSearch'teki tüm kullanıcıları silmek için:

```bash
POST http://localhost:5000/delete-all
```
