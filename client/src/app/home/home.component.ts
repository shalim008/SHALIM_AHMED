import { PostParams } from './../shared/models/postParams';
import { HomeService } from './home.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IPost } from '../shared/models/post';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
   
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
    postParams: PostParams;
    posts: IPost[];
    totalCount = 0;

    constructor(private homeService: HomeService) {
        this.postParams = this.homeService.getPostParams();
    }

    ngOnInit(): void {
        this.getPostReports();
    }

      // tslint:disable-next-line: typedef
  getPostReports() {    
    this.homeService.getPosts().subscribe(response => {
      this.posts = response.data;
      this.totalCount = response.count;
      debugger;
      console.log(this.posts);
    }, error => {
        console.log(error);
    });
  }

      // tslint:disable-next-line: typedef
      onPageChanged(event: any){
        const params = this.homeService.getPostParams();
        if (params.pageNumber !== event)
        {
          params.pageNumber = event;
          this.homeService.setPostParams(params);
          this.getPostReports();
        }
      }


      // tslint:disable-next-line: typedef
    onSearch(){
        const params = this.homeService.getPostParams();
        params.search = this.searchTerm.nativeElement.value;
        params.pageNumber = 1;
        this.homeService.setPostParams(params);
        this.getPostReports();
      }
  
   
    
    

}
