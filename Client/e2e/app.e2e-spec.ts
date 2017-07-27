import { MyApp_ClientPage } from './app.po';

describe('credit-ratings.client App', () => {
  let page: MyApp_ClientPage;

  beforeEach(() => {
    page = new MyApp_ClientPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
