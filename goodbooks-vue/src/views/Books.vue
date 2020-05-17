<template>
  <div class="about">
    <h1>This is Books page</h1>
  </div>
</template>
<script lang="ts">
  import HelloWorld from '@/components/HelloWorld.vue';
  import IBook from '@/types/Book';
  import BookService from '@/services/book-service';

  const bookService = new BookService();

  @components({
    name: 'MyBooks',
    components: {}
  })
  expotr default class MyBooks extend Vue {
    // data
    myBooks: IBook[] = [];
    // computed property
    get bookCount(){
      return this.myBooks.length; 
    }
    // props
    // methods
    // lifecycle hooks
    created(){      
      this.myBooks = bookService.getAllBooks();
    }
    // watcher
  }
</script>

<style lang="scss"> 

</style>