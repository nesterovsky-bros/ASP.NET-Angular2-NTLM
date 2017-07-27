import { Component } from "@angular/core";
import { MyService } from "./my-service";

@Component(
{
  selector: "app",
  templateUrl: "./app.component.html"
})
export class AppComponent
{
  constructor(public myService: MyService)
  {
  }

  x: number;
  y: number;
  s: number;

  sum() {
    this.myService.add(this.x, this.y).
      subscribe(s => this.s = s, e => { this.s = null; alert(e); });
  }
}