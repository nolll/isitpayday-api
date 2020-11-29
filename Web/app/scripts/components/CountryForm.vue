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

<script>
    import { mapGetters } from 'vuex';

    export default {
        computed: {
            ...mapGetters([
                'countries'
            ]),
            country: {
                get() {
                    return this.$store.getters.country;
                },
                set(value) {
                    this.$store.dispatch('selectCountry', value);
                    this.close();
                }
            },
            countryName: function () {
                var i;
                for (i = 0; i < this.countries.length; i++) {
                    const c = this.countries[i];
                    if (c.id === this.country) {
                        return c.name;
                    }
                }
                return '';
            }
        },
        methods: {
            open: function () {
                this.showForm = true;
            },
            close: function () {
                this.showForm = false;
            }
        },
        data: function () {
            return {
                showForm: false
            };
        }
    };
</script>