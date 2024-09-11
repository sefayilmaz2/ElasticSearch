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
- .NET 6 veya üstü
- ElasticSearch (Docker üzerinden ayarlanmıştır)
- Kibana (ElasticSearch'ü izlemek için)

## Kurulum Adımları

### 1. Projeyi Klonlayın

```bash
git clone https://github.com/kullanici-adi/proje-adi.git
cd proje-adi

### 2. Docker Kurulumu

Docker’ın sisteminizde kurulu ve çalışır durumda olduğundan emin olun.

Projenin kök dizininde docker-compose.yml dosyası bulunmaktadır. Bu dosya, ElasticSearch ve Kibana servislerinin ayarlarını içerir.

ElasticSearch ve Kibana’yı başlatmak için aşağıdaki komutu terminalde çalıştırın:

```bash
docker-compose up
