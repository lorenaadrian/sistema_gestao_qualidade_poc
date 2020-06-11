import { ComplianceService } from "./compliance.service";
import { Component, OnInit } from "@angular/core";

declare var $: any;
@Component({
  selector: "app-compliance",
  templateUrl: "./compliance.component.html",
  styleUrls: ["./compliance.component.css"],
})
export class ComplianceComponent implements OnInit {
  constructor(private complianceService: ComplianceService) {}

  ngOnInit(): void {}
  onDownload(fileName: string, spin) {
    spin.style.display = "inline-flex";
    this.complianceService.downloadFile(fileName).subscribe(
      (res: any) => {
        const file = new Blob([res], {
          type: res.type,
        });
        //detect whether the browser is IE/Edge or another browser
        if (window.navigator && window.navigator.msSaveOrOpenBlob) {
          //To IE or Edge browser, using msSaveorOpenBlob method to download file.
          window.navigator.msSaveOrOpenBlob(file, fileName);
        } else {
          //To another browser, create a tag to downlad file.
          const blob = window.URL.createObjectURL(file);
          const link = document.createElement("a");
          link.href = blob;
          link.download = `${fileName}`;
          link.click();
          window.URL.revokeObjectURL(blob);
          link.remove();          
        }        
      },
      (err) => {
        alert(err.status);
      }, () => {spin.style.display = "none";}
    );
  }
}
