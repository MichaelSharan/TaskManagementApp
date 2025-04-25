from locust import HttpUser, task, between

class ApiUser(HttpUser):
    wait_time = between(1, 2)  # Задержка между запросами

    @task(3)  # 3 GET-запроса на 1 POST
    def get_posts(self):
        self.client.get("/posts")

    @task(1)
    def create_post(self):
        self.client.post(
            "/posts",
            json={"title": "Load Test", "author": "Locust"}
        )
