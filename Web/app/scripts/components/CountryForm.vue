<template>
    <div>
        <h3>Country</h3>
        <div class="country-info">
            <p v-show="showForm">
                <select v-model.number="country">
                    <option v-for="c in countries" :value="c.id" :key="c.id">{{c.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!showForm">
                <span v-text="countryName"></span>
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Mixins } from 'vue-property-decorator';
    import { StoreMixin} from '../StoreMixin';
    
    @Component
    export default class App extends Mixins(
        StoreMixin
    ) {
        showForm = false;

        get countryName() {
            var i;
            for (i = 0; i < this.countries.length; i++) {
                const c = this.countries[i];
                if (c.id === this.country) {
                    return c.name;
                }
            }
            return '';
        }

        get country() {
            return this.$store.getters.country;
        }
        
        set country(value) {
            this.$_selectCountry(value);
            this.close();
        }

        get countries(){
            return this.$_countries;
        }

        open() {
            this.showForm = true;
        }

        close() {
            this.showForm = false;
        }

        mounted() {
            this.$_loadSettings();
            this.$_loadPayday();
            this.$_loadOptions();
        }
    }
</script>