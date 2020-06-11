import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnaliseCausaRaizComponent } from './analise-causa-raiz.component';

describe('AnaliseCausaRaizComponent', () => {
  let component: AnaliseCausaRaizComponent;
  let fixture: ComponentFixture<AnaliseCausaRaizComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnaliseCausaRaizComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnaliseCausaRaizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
